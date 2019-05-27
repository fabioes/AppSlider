using System.Net;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Create([FromBody]BusinessCreateRequest user)
        {
            if(user == null) throw new BusinessException("Favor informar os dados do Negócio!");

            var result = await _businessCreateService.Process(new BusinessCreateCommand(user.Name, user.Username, user.Password, user.Email, user.Profile, user.Franchises, user.Roles, user.Active.GetValueOrDefault(true)));

            return Ok(new ApiReturnItem<BusinessResult> { Item = result, Success = true });
        }
    }
}