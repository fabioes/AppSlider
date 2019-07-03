using System;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.Playlist.Services.Delete;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.Playlist.Delete
{
    [Route("api/playlist")]
    public class PlaylistController : Controller
    {
        private readonly IPlaylistDeleteService _playlistDeleteService;

        public PlaylistController(IPlaylistDeleteService playlistDeleteService)
        {
            _playlistDeleteService = playlistDeleteService;
        }

        /// <summary>
        /// Deleta uma Playlist 
        /// 
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WritePlaylist)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<Object>))]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue || id.Value == new Guid()) throw new BusinessException("Favor informar o Id da Playlist!");

            var result = await _playlistDeleteService.Process(id.Value);

            return Ok(new ApiReturnItem<object> { Item = result ? "Playlist deletada com sucesso!" : "Falha ao deletar a Playlist!", Success = result });
        }
    }
}