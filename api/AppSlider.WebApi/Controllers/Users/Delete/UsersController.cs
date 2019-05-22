using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Services.Delete;
using AppSlider.Domain;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Users.Delete
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserDeleteService _userDeleteService;

        public UsersController(IUserDeleteService userDeleteService)
        {
            _userDeleteService = userDeleteService;
        }
        
        /// <summary>
        /// Deleta um Usuário
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<Object>))]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue || id.Value == new Guid()) throw new BusinessException("Favor informar o Id do Usuário!");

            var result = await _userDeleteService.Process(new UserDeleteCommand(id));

            return Ok(new ApiReturnItem<object> { Item = result ? "Usuário deletado com sucesso!" : "Falha ao deletar Usuário!", Success = result });
        }
    }
}