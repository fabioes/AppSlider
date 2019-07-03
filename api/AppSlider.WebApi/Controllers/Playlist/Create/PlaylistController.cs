using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Playlist.Commands;
using AppSlider.Application.Playlist.Messages;
using AppSlider.Application.Playlist.Results;
using AppSlider.Application.Playlist.Services.Create;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Playlist.Create
{
    [Route("api/playlist")]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistCreateService _playlistCreateService;

        public PlaylistController(IPlaylistCreateService playlistCreateService)
        {
            _playlistCreateService = playlistCreateService;
        }

        /// <summary>
        /// Cria uma Playlist
        /// </summary>
        [HttpPost]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WritePlaylist)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<PlaylistResult>))]
        public async Task<IActionResult> Create([FromBody]PlaylistCreateRequest request)
        {
            if (request == null) throw new BusinessException("Favor informar os dados da Playlist");

            var result = await _playlistCreateService.Process(new PlaylistCreateCommand{
                Name = request.Name,
                Active = request.Active,
                Expirate = request.Expirate ?? DateTime.MaxValue,
                FranchiseId = request.FranchiseId                
            });

            return Ok(new ApiReturnItem<PlaylistResult> { Item = result, Success = true });
        }
    }
}