using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Business.Commands;
using AppSlider.Application.Business.Results;
using AppSlider.Application.Business.Services.Update;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Business.Update
{
    [Route("api/business")]
    public class BusinessController : Controller
    {
        private readonly IBusinessUpdateService _businessUpdateService;
        
        public BusinessController(IBusinessUpdateService businessUpdateService)
        {
            _businessUpdateService = businessUpdateService;
        }
        
        /// <summary>
        /// Atualiza um Negócio.
        /// </summary>
        [HttpPut]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteBusiness)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<BusinessResult>))]
        public async Task<IActionResult> Update([FromBody]BusinessUpdateRequestCommand request)
        {
            var result = await _businessUpdateService.Process(request);

            return Ok(new ApiReturnItem<BusinessResult> { Item = result, Success = true });
        }
    }
}