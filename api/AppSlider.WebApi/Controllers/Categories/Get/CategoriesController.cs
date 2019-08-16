using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Category.Results;
using AppSlider.Application.Category.Services.Get;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Categories.Get
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryGetService categoryGetService;
        
        public CategoriesController(ICategoryGetService categoryGetService)
        {
            this.categoryGetService = categoryGetService;        
        }

        /// <summary>
        /// Obtem um ou várias Categorias
        /// </summary>
        [HttpGet("{id?}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadCategory)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<CategoryResult>))]
        public async Task<IActionResult> Get(int? id)
        {
            if (id.HasValue && id.Value != 0)
            {
                var result = await categoryGetService.Get(id.Value);

                return Ok(new ApiReturnItem<CategoryResult> { Item = result, Success = true });
            }

            var results = await categoryGetService.GetAll();

            return Ok(new ApiReturnList<CategoryResult> { Items = results, Success = true });
        }
    }
}