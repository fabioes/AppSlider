using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Equipament.Results;
using AppSlider.Application.Equipament.Services.Config;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Equipament.Config
{
    [Route("api/equipament")]
    public class EquipamentController : Controller
    {
        private readonly IEquipamentConfigService _equipamentConfigService;
        
        public EquipamentController(IEquipamentConfigService equipamentConfigService)
        {
            _equipamentConfigService = equipamentConfigService;
        }
        
        /// <summary>
        /// Ativa ou desativa um Equipamento
        /// </summary>
        [HttpPatch("switch_active/{id}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteEquipament)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<EquipamentResult>))]
        public async Task<IActionResult> SwitchActive(Guid id)
        {
            var result = await _equipamentConfigService.SwitchActive(id);

            return Ok(new ApiReturnItem<EquipamentResult> { Item = result, Success = true });
        }
    }
}