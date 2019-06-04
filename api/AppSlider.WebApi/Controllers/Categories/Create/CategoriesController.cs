using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Category.Messages;
using AppSlider.Application.Category.Results;
using AppSlider.Application.Category.Services.Create;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Categories.Create
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryCreateService _categoryCreateService;

        public CategoriesController(ICategoryCreateService categoryCreateService)
        {
            _categoryCreateService = categoryCreateService;
        }
        
        /// <summary>
        /// Cria uma Categoria
        /// </summary>
        [HttpPost]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteCategory)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<CategoryResult>))]
        public async Task<IActionResult> Create([FromBody]CategoryCreateRequest request)
        {
            if(request== null) throw new BusinessException("Favor informar os dados da Categoria!");

            var result = await _categoryCreateService.Process(new Application.Category.Commands.CategoryCreateCommand(request.Name, request.Description));

            return Ok(new ApiReturnItem<CategoryResult> { Item = result, Success = true });
        }
    }
}