using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AppSlider.Application.User.Services.Get;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.Domain.Entities.Users;
using AppSlider.Utils.Cripto;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace AppSlider.WebApi.Filters
{
    public class CustomAuthorizeFilter : IAsyncAuthorizationFilter
    {
        private  LoggedUser _loggedUser { get; set; }
        public AuthorizationPolicy Policy { get; }

        private readonly IUserGetService _userGetService;

        public CustomAuthorizeFilter(
            IUserGetService userGetService,
            AuthorizationPolicy policy, [FromServices]LoggedUser loggedUser)
        {
            //_loggedUser = loggedUser;
            _userGetService = userGetService;
            Policy = policy ?? throw new ArgumentNullException(nameof(policy));
            _loggedUser = loggedUser;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // Allow Anonymous skips all authorization
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }

            var policyEvaluator = context.HttpContext.RequestServices.GetRequiredService<IPolicyEvaluator>();
            var authenticateResult = await policyEvaluator.AuthenticateAsync(Policy, context.HttpContext);
            var authorizeResult =
                await policyEvaluator.AuthorizeAsync(Policy, authenticateResult, context.HttpContext, context);

            if (authorizeResult.Challenged)
            {
                // Return custom 401 result
                context.Result = new CustomUnauthorizedResultError("Permissão Negada!");
            }
            else if (authorizeResult.Forbidden)
            {
                // Return default 403 result
                context.Result = new ForbidResult(Policy.AuthenticationSchemes.ToArray());
            }
            else
            {
                try
                {
                    context.HttpContext.Request.Headers.TryGetValue("Authorization",
                        out StringValues authorization);
                    var token =
                        authorization.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                    var handler = new JwtSecurityTokenHandler();
                    var decodedToken = handler.ReadToken(token) as JwtSecurityToken;
                    var userToken = decodedToken.Claims.First(claim => claim.Type == "unique_name").Value;

                    var user = await _userGetService.GetByUsername(userToken);
                    _loggedUser.UserName = user.Username;
                    _loggedUser.Profile = user.Profile;
                    _loggedUser.Id = user.Id;
                    _loggedUser.Franchises = user.Franchises;
                    _loggedUser.Roles = user.Roles;
                    _loggedUser.RolesNames = user.RolesNames;

                    if (String.IsNullOrWhiteSpace(_loggedUser?.UserName))
                    {
                        new CustomUnauthorizedResultError($"Permissão Negada! - Usuário: {userToken} inválido!");
                        return;
                    }

                    if (user?.Active != true)
                    {
                        context.Result = new CustomUnauthorizedResultError($"Permissão Negada! - Usuário: {userToken} está inativo!");
                        return;
                    }

                    if (!ValidateUserRoutePermission(decodedToken, context))
                    {
                        // Return custom 401 result
                        context.Result = new CustomUnauthorizedResultError("Permissão Negada - Rota liberada apenas para Administradores.");
                    }
                }
                catch (Exception ex)
                {
                    throw new BusinessException(
                        "Erro ao validar token / usuário!. Favor realizar o Login novamente!", ex,
                        "CustomAuthorizeFilter - SetLoggedUser");
                }
            }
        }

        private bool ValidateUserRoutePermission(JwtSecurityToken token, AuthorizationFilterContext context)
        {
            if (_loggedUser.Profile == "sa")
                return true;

            //Verify if the route has CustomAuthorizeAttribute.
            var customAuthorizeAttribute = ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.CustomAttributes
                .FirstOrDefault(f => f.AttributeType == typeof(CustomAuthorizeAttribute));

            if (customAuthorizeAttribute == null)
                return true;


            var role = customAuthorizeAttribute.ConstructorArguments.FirstOrDefault();
            return role != null && ((_loggedUser.Roles ?? new List<string>()).Contains(role.Value?.ToString() ?? "_") || (_loggedUser.RolesNames ?? new List<string>()).Contains(role.Value?.ToString() ?? "_"));

        }
    }
}