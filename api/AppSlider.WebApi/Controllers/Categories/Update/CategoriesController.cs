using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Category.Messages;
using AppSlider.Application.Category.Results;
using AppSlider.Application.Category.Services.Update;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Categories.Update
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryUpdateService _categoryUpdateService;
        
        public CategoriesController(ICategoryUpdateService categoryUpdateService)
        {
            _categoryUpdateService = categoryUpdateService;
        }
        
        /// <summary>
        /// Atualiza uma Categoria.
        /// </summary>
        [HttpPut]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteCategory)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<CategoryResult>))]
        public async Task<IActionResult> Update([FromBody]CategoryUpdateRequest request)
        {
            var result = await _categoryUpdateService.Process(new AppSlider.Application.Category.Commands.CategoryUpdateCommand(request.Id, request.Name, request.Description));

            return Ok(new ApiReturnItem<CategoryResult> { Item = result, Success = true });
        }
    }
}