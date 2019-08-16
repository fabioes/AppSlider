using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Category.Services.Delete;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Categories.Delete
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryDeleteService _categoryDeleteService;

        public CategoriesController(ICategoryDeleteService categoryDeleteService)
        {
            _categoryDeleteService = categoryDeleteService;
        }
        
        /// <summary>
        /// Deleta uma Categoria 
        /// 
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteCategory)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<Object>))]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue || id.Value == 0) throw new BusinessException("Favor informar o Id da Categoria!");

            var result = await _categoryDeleteService.Process(id.Value);

            return Ok(new ApiReturnItem<object> { Item = result ? "Categoria deletada com sucesso!" : "Falha ao deletar a Categoria!", Success = result });
        }
    }
}