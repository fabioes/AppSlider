using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Playlist.Results;
using AppSlider.Application.Playlist.Services.Get;
using AppSlider.Application.TypeBusiness.Results;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Playlist.Get
{
    [Route("api/playlist")]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistGetService _playlistGetService;

        public PlaylistController(IPlaylistGetService playlistGetService)
        {
            _playlistGetService = playlistGetService;
        }

        /// <summary>
        /// Obtem uma ou várias Playlists
        /// </summary>
        [HttpGet("{id?}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadPlaylist)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<PlaylistResult>))]
        public async Task<IActionResult> Get(Guid? id)
        {
            if (id.HasValue && id.Value != new Guid())
            {
                var result = await _playlistGetService.Get(id.Value);

                return Ok(new ApiReturnItem<PlaylistResult> { Item = result, Success = true });
            }

            var results = await _playlistGetService.GetAll();

            return Ok(new ApiReturnList<PlaylistResult> { Items = results, Success = true });
        }

        /// <summary>
        /// Obtem as Playlists de uma dada franquia
        /// </summary>
        [HttpGet("GetByFranchise/{idFranchise}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.ReadPlaylist)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<PlaylistResult>))]
        public async Task<IActionResult> GetByFranchise(Guid idFranchise)
        {
            var results = await _playlistGetService.GetByFranchise(idFranchise);

            return Ok(new ApiReturnList<PlaylistResult> { Items = results, Success = true });
        }
    }
}