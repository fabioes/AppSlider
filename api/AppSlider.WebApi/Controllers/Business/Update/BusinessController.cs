using System.Net;
using System.Threading.Tasks;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AtlasChatbotApi.WebApi.Controllers.Users.Update
{
    [Route("api/business")]
    public class BusinessController : Controller
    {
        private readonly IBusinessUpdateService _businessUpdateService;
        
        public BusinessController(IBusinessUpdateService businessUpdateService)
        {
            _businessUpdateService = businessUpdateService;
        }
        
        /// <summary>
        /// Atualiza um Negócio.
        /// </summary>
        [HttpPut]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteBusiness)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<BusinessResult>))]
        public async Task<IActionResult> Update([FromBody]BusinessUpdateRequest user)
        {
            var result = await _userUpdateService.Process(new BusinessUpdateCommand(user.Id, user.Name, user.Username, user.Password, user.Email, user.Profile, user.Franchises, user.Roles, user.Active.GetValueOrDefault(true)));

            return Ok(new ApiReturnItem<BusinessResult> { Item = result, Success = true });
        }
    }
}