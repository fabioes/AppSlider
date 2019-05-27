using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Business.Delete
{
    [Route("api/business")]
    public class BusinessController : Controller
    {
        private readonly IBusinessDeleteService _businessDeleteService;

        public BusinessController(IBusinessDeleteService businessDeleteService)
        {
            _businessDeleteService = businessDeleteService;
        }
        
        /// <summary>
        /// Deleta um Negócio
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteBusiness)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<Object>))]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue || id.Value == new Guid()) throw new BusinessException("Favor informar o Id do Negócio!");

            var result = await _businessDeleteService.Process(new BusinessDeleteCommand(id));

            return Ok(new ApiReturnItem<object> { Item = result ? "Negócio deletado com sucesso!" : "Falha ao deletar Negócio!", Success = result });
        }
    }
}