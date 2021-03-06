using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Business.Results;
using AppSlider.Application.Business.Services.Get;
using AppSlider.Application.Equipament.Services.Get;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Business.Get
{
    [Route("api/business")]
    public class BusinessController : Controller
    {
        private readonly IBusinessGetService _businessGetService;
        private readonly IEquipamentGetService _equipamentGetService;

        public BusinessController(IBusinessGetService businessGetService, IEquipamentGetService equipamentGetService)
        {
            _businessGetService = businessGetService;
            _equipamentGetService = equipamentGetService;
        }

        /// <summary>
        /// Obtem um ou vários Negócios
        /// </summary>
        [HttpGet("{id?}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadBusiness)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<BusinessResult>))]
        public async Task<IActionResult> Get(Guid? id)
        {
            if (id.HasValue && id.Value != new Guid())
            {
                var result = await _businessGetService.Get(id.Value);

                return Ok(new ApiReturnItem<BusinessResult> { Item = result, Success = true });
            }

            var results = await _businessGetService.GetAll();

            return Ok(new ApiReturnList<BusinessResult> { Items = results, Success = true });
        }

        /// <summary>
        /// Obtem um ou vários Negócios por tipo
        /// </summary>
        [HttpGet("GetByType/{type}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadBusiness)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<BusinessResult>))]
        public async Task<IActionResult> GetByType(String type)
        {
            var results = await _businessGetService.GetByType(type);

            return Ok(new ApiReturnList<BusinessResult> { Items = results, Success = true });
        }

        /// <summary>
        /// Obtem um ou vários Negócios por tipo
        /// </summary>
        [HttpGet("GetByType/{franchiseId}/{type}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadBusiness)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<BusinessResult>))]
        public async Task<IActionResult> GetByType(String franchiseId, String type)
        {
            var results = await _businessGetService.GetByFranchiseAndType(franchiseId, type);

            foreach (var item in results)
            {

                item.Equipaments = await _equipamentGetService.GetSelectedByAdvertiser(item.Id);
            }

            return Ok(new ApiReturnList<BusinessResult> { Items = results, Success = true });
        }

        /// <summary>
        /// Obtem um ou vários Negócios por tipo
        /// </summary>
        [HttpGet("advertisers")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadBusiness)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<BusinessResult>))]
        public async Task<IActionResult> GetByType(String franchiseId, String type, String page)
        {
            int pageNumber = Convert.ToInt32(page);
            var results = await _businessGetService.GetByFranchiseAndType(franchiseId, type, pageNumber);

            foreach (var item in results)
            {

                item.Equipaments = await _equipamentGetService.GetSelectedByAdvertiser(item.Id);
            }

            return Ok(new ApiReturnList<BusinessResult> { Items = results, Success = true });
        }
        /// <summary>
        /// Obtem um ou vários Negócios por tipo
        /// </summary>
        [HttpGet("count")]

        public async Task<IActionResult> Count([FromQuery] String franchiseId, [FromQuery] String type)
        {

            var results = await _businessGetService.CountItems(franchiseId, type);



            return Ok(results);
        }
        /// <summary>
        /// Obtem um ou vários Negócios por tipo
        /// </summary>
        [HttpGet("GetForLoggedUser")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadBusiness)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<BusinessResult>))]
        public async Task<IActionResult> GetForLoggedUser()
        {
            var results = await _businessGetService.GetForLoggedUser();

            return Ok(new ApiReturnList<BusinessResult> { Items = results, Success = true });
        }

    }
}