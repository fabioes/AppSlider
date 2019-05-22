using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Results;
using AppSlider.Application.User.Services.Get;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Users.Get
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserGetService _userGetService;
        
        public UsersController(IUserGetService userGetService)
        {
            _userGetService = userGetService;
        
        }

        /// <summary>
        /// Obtem um ou vários Usuários
        /// </summary>
        [HttpGet("{id?}")]
        [Authorize("Bearer")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<UserResult>))]
        public async Task<IActionResult> Get(Guid? id)
        {
            if (id.HasValue && id.Value != new Guid())
            {
                var command = new UserGetCommand(id.Value);
                var result = await _userGetService.Get(command);

                return Ok(new ApiReturnItem<UserResult> { Item = result, Success = true });
            }

            var results = await _userGetService.GetAll();

            return Ok(new ApiReturnList<UserResult> { Items = results, Success = true });
        }
    }
}