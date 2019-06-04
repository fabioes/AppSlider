using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.TypeBusiness.Services.Delete;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.TypeBusiness.Delete
{
    [Route("api/business_type")]
    public class TypeBusinessController : Controller
    {
        private readonly ITypeBusinessDeleteService _typeBusinessDeleteService;

        public TypeBusinessController(ITypeBusinessDeleteService typeBusinessDeleteService)
        {
            _typeBusinessDeleteService = typeBusinessDeleteService;
        }
        
        /// <summary>
        /// Deleta um Tipo de Negócio 
        /// 
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteBusinessType)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<Object>))]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue || id.Value == new Guid()) throw new BusinessException("Favor informar o Id do Tipo de Negócio!");

            var result = await _typeBusinessDeleteService.Process(id.Value);

            return Ok(new ApiReturnItem<object> { Item = result ? "Tipo de Negócio deletado com sucesso!" : "Falha ao deletar o Tipo de Negócio!", Success = result });
        }
    }
}