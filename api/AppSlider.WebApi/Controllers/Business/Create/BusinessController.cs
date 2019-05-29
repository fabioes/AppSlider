using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Business.Commands;
using AppSlider.Application.Business.Results;
using AppSlider.Application.Business.Services.Create;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Business.Create
{
    [Route("api/business")]
    public class BusinessController : Controller
    {
        private readonly IBusinessCreateService _businessCreateService;

        public BusinessController(IBusinessCreateService businessCreateService)
        {
            _businessCreateService = businessCreateService;
        }
        
        /// <summary>
        /// Cria um Negócio
        /// </summary>
        [HttpPost]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteBusiness)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<BusinessResult>))]
        public async Task<IActionResult> Create([FromBody]BusinessCreateRequestCommand request)
        {
            if(request== null) throw new BusinessException("Favor informar os dados do Negócio!");

            var result = await _businessCreateService.Process(request);

            return Ok(new ApiReturnItem<BusinessResult> { Item = result, Success = true });
        }
    }
}