using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Playlist.Commands;
using AppSlider.Application.Playlist.Messages;
using AppSlider.Application.Playlist.Results;
using AppSlider.Application.Playlist.Services.Update;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Playlist.Update
{
    [Route("api/playlist")]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistUpdateService _playlistUpdateService;

        public PlaylistController(IPlaylistUpdateService playlistUpdateService)
        {
            _playlistUpdateService = playlistUpdateService;
        }

        /// <summary>
        /// Atualiza uma Playlist.
        /// </summary>
        [HttpPut]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WritePlaylist)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<PlaylistResult>))]
        public async Task<IActionResult> Update([FromBody]PlaylistUpdateRequest request)
        {
            var result = await _playlistUpdateService.Process(new PlaylistUpdateCommand
            {
                Id = request.Id,
                Active = request.Active,
                Expirate = request.Expirate ?? DateTime.MaxValue,
                FranchiseId = request.FranchiseId,
                Name = request.Name
            });

            return Ok(new ApiReturnItem<PlaylistResult> { Item = result, Success = true });
        }
    }
}