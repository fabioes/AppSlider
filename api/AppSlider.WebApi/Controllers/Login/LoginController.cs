using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using AppSlider.Application.Business.Services.Get;
using AppSlider.Application.Login.Messages;
using AppSlider.Application.Login.Services;
using AppSlider.Application.Role.Services.Get;
using AppSlider.Application.User.Results;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.Entities.Users;
using AppSlider.Utils.Cripto;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Login
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IRoleGetService _rolesService;
        private readonly IBusinessGetService _businessService;

        public LoginController(ILoginService loginService, IRoleGetService rolesService, IBusinessGetService businessService)
        {
            _loginService = loginService;
            _rolesService = rolesService;
            _businessService = businessService;
        }

        /// <summary>
        /// Realiza o Login e disponibilização do Token para consumo da API.
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<LoginResponse>))]
        public async Task<Object> PostAsync(
            [FromBody]LoginRequest login,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            if (login != null)
            {
                UserResult user = await _loginService.Process(new LoginRequest { Username = login.Username, Password = login.Password });

                if (user == null)
                    throw new BusinessException("Falha ao Authenticar!");

                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(login.Username, user.Profile),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    }
                );
                
                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });

                var loggedUser = new LoggedUser
                {
                    Franchises = user.Franchises,
                    Id = user.Id,
                    Login = user.Username,
                    Profile = user.Profile,
                    Roles = user.Roles,
                    UserName = user.Username
                };

                //Custom Claims                
                    var roles = await _rolesService.GetFromUser(loggedUser);
                (securityToken as JwtSecurityToken).Payload["roles"] = roles.Select(s => s.Name).ToList();

                var franchises = await _businessService.GetFromUser(loggedUser);
                (securityToken as JwtSecurityToken).Payload["franchises"] = franchises.Select(s => new { id = s.Id.ToString(), name = s.Name }).ToList();

                var token = handler.WriteToken(securityToken);

                return new ApiReturnItem<LoginResponse>
                {
                    ApiReturnMessage = new ApiReturnMessage { Title = "Operação realizada com sucesso!" },
                    Success = true,
                    Item = new LoginResponse
                    {
                        Success = true,
                        CreationData = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                        ExpirationData = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                        Token = token,
                        User = user.Username,
                        UserProfile = user.Profile
                    }

                };
            }

            throw new BusinessException("Falha ao Authenticar!");
        }
    }
}