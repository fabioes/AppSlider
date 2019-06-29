using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.File.Services;
using AppSlider.Application.TypeBusiness.Results;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Files
{
    [Route("api/files")]
    public class FileController : Controller
    {
        private readonly IFileGetService _fileGetService;
        
        public FileController(IFileGetService fileGetService)
        {
            this._fileGetService = fileGetService;        
        }

        /// <summary>
        /// Obtem um arquivo para download
        /// </summary>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(FileContentResult))]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _fileGetService.Process(id);

            return File(result.Data, result.ContentType, string.IsNullOrWhiteSpace(result.Name) ? id.ToString() : result.Name);
        }
    }
}