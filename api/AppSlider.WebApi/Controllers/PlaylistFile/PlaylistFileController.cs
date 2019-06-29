using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AppSlider.Application.PlaylistFile.Messages;
using AppSlider.Application.PlaylistFile.Results;
using AppSlider.Application.PlaylistFile.Services;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.CustomAttributes;
using AppSlider.WebApi.Model;
using AppSlider.WebApi.ModelBinders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Controllers.TypeBusiness.Create
{
    [Route("api/playlist_file")]
    public class PlaylistFileController : Controller
    {
        private readonly IPlaylistFileService _playlistFileService;

        public PlaylistFileController(IPlaylistFileService playlistFileService)
        {
            _playlistFileService = playlistFileService;
        }

        /// <summary>
        /// Cria um Item (PlaylistFile) para uma playlist.
        /// </summary>
        [HttpPost]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WritePlaylist)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<PlaylistFileResult>))]
        public async Task<IActionResult> Create([ModelBinder(BinderType = typeof(JsonModelBinder))] PlaylistFileCreateRequest value, IList<IFormFile> files)
        {
            var file = files[0];

            var fileMS = new MemoryStream();
            file.CopyTo(fileMS);

            if (value == null) throw new BusinessException("Favor informar os dados do Item da Playlist!");

            var result = await _playlistFileService.ProcessCreate(new Application.PlaylistFile.Commands.PlaylistFileCommand {
                Duration = value.Duration,
                IdPlayList = value.IdPlayList,
                PlayListFileType = value.PlayListFileType,
                FileData = fileMS.ToArray(),
                FileName = file.FileName,
                FileMimeType = file.ContentType,
                FileSize = file.Length
            });

            return Ok(new ApiReturnItem<PlaylistFileResult> { Item = result, Success = true });
        }

        /// <summary>
        /// Deleta um Item (PlaylistFile) de uma playlist.
        /// </summary>
        [HttpDelete("{idPlaylist}/{id}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WritePlaylist)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<PlaylistFileResult>))]
        public async Task<IActionResult> Delete(Guid idPlaylist, Guid id)
        {
            var result = await _playlistFileService.ProcessDelete(idPlaylist,id);

            return Ok(new ApiReturnItem<Boolean> { Item = result, Success = true });
        }
    }
}