using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Playlist.Results;
using AppSlider.Application.Playlist.Services.Config;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Business.Config
{
    [Route("api/playlist")]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistConfigService _playlistConfigService;
        
        public PlaylistController(IPlaylistConfigService playlistConfigService)
        {
            _playlistConfigService = playlistConfigService;
        }
        
        /// <summary>
        /// Ativa ou desativa uma Playlist.
        /// </summary>
        [HttpPatch("switch_active/{id}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WriteBusiness)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<PlaylistResult>))]
        public async Task<IActionResult> SwitchActive(Guid id)
        {
            var result = await _playlistConfigService.SwitchActive(id);

            return Ok(new ApiReturnItem<PlaylistResult> { Item = result, Success = true });
        }
    }
}