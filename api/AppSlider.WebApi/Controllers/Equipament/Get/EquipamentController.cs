using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Equipament.Results;
using AppSlider.Application.Equipament.Services.Get;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Equipament.Get
{
    [Route("api/equipament")]
    public class EquipamentController : Controller
    {
        private readonly IEquipamentGetService _equipamentGetService;
        
        public EquipamentController(IEquipamentGetService equipamentGetService)
        {
            _equipamentGetService = equipamentGetService;        
        }

        /// <summary>
        /// Obtem um ou vários Equipamentos
        /// </summary>
        [HttpGet("{id?}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadEquipament)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<EquipamentResult>))]
        public async Task<IActionResult> Get(Guid? id)
        {
            if (id.HasValue && id.Value != new Guid())
            {
                var result = await _equipamentGetService.Get(id.Value);

                return Ok(new ApiReturnItem<EquipamentResult> { Item = result, Success = true });
            }

            var results = await _equipamentGetService.GetAll();

            return Ok(new ApiReturnList<EquipamentResult> { Items = results, Success = true });
        }

        /// <summary>
        /// Obtem Equipamentos para uma franquia
        /// </summary>
        [HttpGet("GetByFranchise/{franchiseId}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadEquipament)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnList<EquipamentResult>))]
        public async Task<IActionResult> GetByType(String franchiseId)
     {
            var results = await _equipamentGetService.GetByFranchise(Guid.Parse(franchiseId));

            return Ok(new ApiReturnList<EquipamentResult> { Items = results, Success = true });
        }

        /// <summary>
        /// Obtem Equipamentos para um estabelecimento
        /// </summary>
        [HttpGet("GetByEstablishment/{establismentId}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadEquipament)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnList<EquipamentResult>))]
        public async Task<IActionResult> GetByEstablishment(String establismentId)
        {
            var results = await _equipamentGetService.GetByEstablishment(Guid.Parse(establismentId));

            return Ok(new ApiReturnList<EquipamentResult> { Items = results, Success = true });
        }

        /// <summary>
        /// Obtem um Equipamento pelo seu MacAddress
        /// </summary>
        [HttpGet("GetByMacAddress/{macAddress}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadEquipament)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<EquipamentResult>))]
        public async Task<IActionResult> GetByMacAddress(String macAddress)
        {
            var result = await _equipamentGetService.GetByMacAddress(macAddress);

            return Ok(new ApiReturnItem<EquipamentResult> { Item = result, Success = true });
        }
    }
}