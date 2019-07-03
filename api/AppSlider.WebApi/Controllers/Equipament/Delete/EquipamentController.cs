using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Equipament.Services.Delete;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Equipament.Delete
{
    [Route("api/equipament")]
    public class EquipamentController : Controller
    {
        private readonly IEquipamentDeleteService _equipamentDeleteService;

        public EquipamentController(IEquipamentDeleteService equipamentDeleteService)
        {
            _equipamentDeleteService = equipamentDeleteService;
        }
        
        /// <summary>
        /// Deleta um Equipamento
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteEquipament)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<Object>))]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == new Guid()) throw new BusinessException("Favor informar o Id do Equipamento!");

            var result = await _equipamentDeleteService.Process(id);

            return Ok(new ApiReturnItem<object> { Item = result ? "Equipamento deletado com sucesso!" : "Falha ao deletar Equipamento!", Success = result });
        }
    }
}