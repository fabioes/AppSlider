using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Equipament.Commands;
using AppSlider.Application.Equipament.Messages;
using AppSlider.Application.Equipament.Results;
using AppSlider.Application.Equipament.Services.Update;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Equipament.Update
{
    [Route("api/equipament")]
    public class EquipamentController : Controller
    {
        private readonly IEquipamentUpdateService _equipamentUpdateService;
        
        public EquipamentController(IEquipamentUpdateService equipamentUpdateService)
        {
            _equipamentUpdateService = equipamentUpdateService;
        }
        
        /// <summary>
        /// Atualiza um Equipamento.
        /// </summary>
        [HttpPut]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteEquipament)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<EquipamentResult>))]
        public async Task<IActionResult> Update([FromBody]EquipamentUpdateRequest request)
        {
            var result = await _equipamentUpdateService.Process(new EquipamentUpdateCommand(request.Id,
                request.Name,
                request.Description,
                request.MacAddress,
                request.IdFranchise,
                request.IdEstablishment,
                request.IdPlaylist,
                request.Active));

            return Ok(new ApiReturnItem<EquipamentResult> { Item = result, Success = true });
        }
    }
}