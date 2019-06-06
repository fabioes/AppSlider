using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.TypeBusiness.Messages;
using AppSlider.Application.TypeBusiness.Results;
using AppSlider.Application.TypeBusiness.Services.Update;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AtlasChatbotApi.WebApi.Controllers.Categories.Update
{
    [Route("api/business_type")]
    public class TypeBusinessController : Controller
    {
        private readonly ITypeBusinessUpdateService _typeBusinessUpdateService;
        
        public TypeBusinessController(ITypeBusinessUpdateService typeBusinessUpdateService)
        {
            _typeBusinessUpdateService = typeBusinessUpdateService;
        }
        
        /// <summary>
        /// Atualiza um Tipo de Negócio.
        /// </summary>
        [HttpPut]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteBusinessType)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<TypeBusinessResult>))]
        public async Task<IActionResult> Update([FromBody]TypeBusinessUpdateRequest request)
        {
            var result = await _typeBusinessUpdateService.Process(new AppSlider.Application.TypeBusiness.Commands.TypeBusinessUpdateCommand(request.Id, request.Name, request.Description));

            return Ok(new ApiReturnItem<TypeBusinessResult> { Item = result, Success = true });
        }
    }
}