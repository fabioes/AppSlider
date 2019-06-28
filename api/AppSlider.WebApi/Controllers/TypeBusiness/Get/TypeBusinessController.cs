using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.TypeBusiness.Results;
using AppSlider.Application.TypeBusiness.Services.Get;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.TypeBusiness.Get
{
    [Route("api/business_type")]
    public class TypeBusinessController : Controller
    {
        private readonly ITypeBusinessGetService typeBusinessGetService;
        
        public TypeBusinessController(ITypeBusinessGetService typeBusinessGetService)
        {
            this.typeBusinessGetService = typeBusinessGetService;        
        }

        /// <summary>
        /// Obtem um ou vários Tipos de Negócio
        /// </summary>
        [HttpGet("{id?}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadBusinessType)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<TypeBusinessResult>))]
        public async Task<IActionResult> Get(Guid? id)
        {
            if (id.HasValue && id.Value != new Guid())
            {
                var result = await typeBusinessGetService.Get(id.Value);

                return Ok(new ApiReturnItem<TypeBusinessResult> { Item = result, Success = true });
            }

            var results = await typeBusinessGetService.GetAll();

            return Ok(new ApiReturnList<TypeBusinessResult> { Items = results, Success = true });
        }
    }
}