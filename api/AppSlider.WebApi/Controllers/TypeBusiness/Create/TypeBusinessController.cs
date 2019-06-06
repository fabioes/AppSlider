using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Category.Messages;
using AppSlider.Application.TypeBusiness.Results;
using AppSlider.Application.TypeBusiness.Services.Create;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.TypeBusiness.Create
{
    [Route("api/business_type")]
    public class TypeBusinessController : Controller
    {
        private readonly ITypeBusinessCreateService _typeBusinessCreateService;

        public TypeBusinessController(ITypeBusinessCreateService typeBusinessCreateService)
        {
            _typeBusinessCreateService = typeBusinessCreateService;
        }
        
        /// <summary>
        /// Cria um Tipo de Negócio
        /// </summary>
        [HttpPost]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteBusinessType)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<TypeBusinessResult>))]
        public async Task<IActionResult> Create([FromBody]TypeBusinessCreateRequest request)
        {
            if(request== null) throw new BusinessException("Favor informar os dados do Tipo de Negócio!");

            var result = await _typeBusinessCreateService.Process(new Application.TypeBusiness.Commands.TypeBusinessCreateCommand(request.Name, request.Description));

            return Ok(new ApiReturnItem<TypeBusinessResult> { Item = result, Success = true });
        }
    }
}