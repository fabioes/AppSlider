using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Business.Config
{
    [Route("api/business")]
    public class BusinessController : Controller
    {
        private readonly IBusinessConfigService _businessConfigService;
        
        public BusinessController(IBusinessConfigService businessConfigService)
        {
            _businessConfigService = businessConfigService;
        }
        
        /// <summary>
        /// Ativa ou desativa um Negócio
        /// </summary>
        [HttpPatch("switch_active/{id}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteBusiness)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<BusinessResult>))]
        public async Task<IActionResult> SwitchActive(Guid id)
        {
            var result = await _businessConfigService.SwitchActive( new BusinessConfigCommand(id));

            return Ok(new ApiReturnItem<BusinessResult> { Item = result, Success = true });
        }
    }
}