using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Equipament.Commands;
using AppSlider.Application.Equipament.Messages;
using AppSlider.Application.Equipament.Results;
using AppSlider.Application.Equipament.Services.Create;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Equipament.Create
{
    [Route("api/equipament")]
    public class EquipamentController : Controller
    {
        private readonly IEquipamentCreateService _equipamentCreateService;

        public EquipamentController(IEquipamentCreateService equipamentCreateService)
        {
            _equipamentCreateService = equipamentCreateService;
        }

        /// <summary>
        /// Cria um Equipamento
        /// </summary>
        [HttpPost]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteEquipament)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<EquipamentResult>))]
        public async Task<IActionResult> Create([FromBody]EquipamentCreateRequest request)
        {
            if (request == null) throw new BusinessException("Favor informar os dados do Equipamento!");

            var result = await _equipamentCreateService.Process(new EquipamentCreateCommand(request.Name,
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