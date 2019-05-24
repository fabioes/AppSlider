using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Messages;
using AppSlider.Application.User.Results;
using AppSlider.Application.User.Services.Update;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AtlasChatbotApi.WebApi.Controllers.Users.Update
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserUpdateService _userUpdateService;
        
        public UsersController(IUserUpdateService userUpdateService)
        {
        _userUpdateService = userUpdateService;
        }
        
        /// <summary>
        /// Atualiza um Usuário
        /// </summary>
        [HttpPut]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteUser)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<UserResult>))]
        public async Task<IActionResult> Update([FromBody]UserUpdateRequest user)
        {
            var result = await _userUpdateService.Process(new UserUpdateCommand(user.Id, user.Name, user.Username, user.Password, user.Email, user.Profile, user.Franchises, user.Roles, user.Active.GetValueOrDefault(true)));

            return Ok(new ApiReturnItem<UserResult> { Item = result, Success = true });
        }
    }
}