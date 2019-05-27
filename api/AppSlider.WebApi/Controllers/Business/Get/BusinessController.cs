using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Users.Get
{
    [Route("api/business")]
    public class BusinessController : Controller
    {
        private readonly IBusinessGetService _businessGetService;
        
        public BusinessController(IBusinessGetService businessGetService)
        {
            _businessGetService = businessGetService;        
        }

        /// <summary>
        /// Obtem um ou vários Usuários
        /// </summary>
        [HttpGet("{id?}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadBusiness)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<BusinessResult>))]
        public async Task<IActionResult> Get(Guid? id)
        {
            if (id.HasValue && id.Value != new Guid())
            {
                var command = new BusinessGetCommand(id.Value);
                var result = await _businessGetService.Get(command);

                return Ok(new ApiReturnItem<BusinessResult> { Item = result, Success = true });
            }

            var results = await _businessGetService.GetAll();

            return Ok(new ApiReturnList<BusinessResult> { Items = results, Success = true });
        }
    }
}