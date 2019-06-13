using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Messages;
using AppSlider.Application.User.Results;
using AppSlider.Application.User.Services.Create;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Users.Create
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserCreateService _userCreateService;

        public UsersController(IUserCreateService userCreateService)
        {
            _userCreateService = userCreateService;
        }
        
        /// <summary>
        /// Cria um Usuário
        /// </summary>
        [HttpPost]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteUser)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<UserResult>))]
        public async Task<IActionResult> Create([FromBody]UserCreateRequest user)
        {
            if(user == null) throw new BusinessException("Favor informar os dados do Usuário!");

            var result = await _userCreateService.Process(new UserCreateCommand(user.Name,
                user.Username,
                user.Password,
                user.Email,
                user.Profile,
                user.Franchises,
                user.Roles,
                user.Active.GetValueOrDefault(true)));

            return Ok(new ApiReturnItem<UserResult> { Item = result, Success = true });
        }
    }
}