using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Messages;
using AppSlider.Application.User.Results;
using AppSlider.Application.User.Services.Config;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Users.Config
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserConfigService _userConfigService;
        
        public UsersController(IUserConfigService userConfigService)
        {
            _userConfigService = userConfigService;
        }
        
        /// <summary>
        /// Ativa ou desativa um Usuário
        /// </summary>
        [HttpPatch("switch_active/{id}")]
        [Authorize("Bearer")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<UserResult>))]
        public async Task<IActionResult> SwitchActive(Guid id)
        {
            var result = await _userConfigService.SwitchActive( new UserConfigCommand(id));

            return Ok(new ApiReturnItem<UserResult> { Item = result, Success = true });
        }

        /// <summary>
        /// Reseta a senha de um Usuário.
        /// </summary>
        [HttpPatch("reset_password")]
        [Authorize("Bearer")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<UserResult>))]
        public async Task<IActionResult> ResetPassword([FromBody]UserResetPasswordRequest user)
        {
            var result = await _userConfigService.ResetPassword(new UserConfigCommand(user.Id, user.Password));

            return Ok(new ApiReturnItem<UserResult> { Item = result, Success = true });
        }
    }
}