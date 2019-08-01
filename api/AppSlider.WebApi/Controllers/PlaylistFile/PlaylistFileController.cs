using AppSlider.Application.Playlist.Commands;
using AppSlider.Application.Playlist.Services.Create;
using AppSlider.Application.Playlist.Services.Get;
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AppSlider.WebApi.Controllers.TypeBusiness.Create
{
    [Route("api/playlist_file")]
    public class PlaylistFileController : Controller
    {
        private readonly IPlaylistFileService _playlistFileService;
        private readonly IPlaylistCreateService _playlistCreateService;
        private readonly IPlaylistGetService _playlistGetService;

        public PlaylistFileController(IPlaylistFileService playlistFileService, IPlaylistCreateService playlistCreateService, IPlaylistGetService playlistGetService)
        {
            _playlistFileService = playlistFileService;
            _playlistCreateService = playlistCreateService;
            _playlistGetService = playlistGetService;
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
            PlaylistFileResult result;
            var file = files[0];

            var fileMS = new MemoryStream();
            file.CopyTo(fileMS);

            if (value == null) throw new BusinessException("Favor informar os dados do Item da Playlist!");

            var playlistBanco = await _playlistGetService.GetByFranchise(value.IdBusiness);
            if (playlistBanco.Count > 0)
            {

                result = await _playlistFileService.ProcessCreate(new Application.PlaylistFile.Commands.PlaylistFileCommand
                {
                    Duration = value.Duration,
                    IdPlayList = playlistBanco[0].Id,
                    PlayListFileType = value.PlayListFileType,
                    FileData = fileMS.ToArray(),
                    FileName = file.FileName,
                    FileMimeType = file.ContentType,
                    FileSize = file.Length
                });
            }
            else
            {

                //Salvar playlist primeiro
                var playlist = await _playlistCreateService.Process(new PlaylistCreateCommand
                {
                    Active = true,
                    Expirate = DateTime.Now.AddYears(1),
                    BusinessId = value.IdBusiness
                });
                //Depois o arquivo 
                result = await _playlistFileService.ProcessCreate(new Application.PlaylistFile.Commands.PlaylistFileCommand
                {
                    Duration = value.Duration,
                    IdPlayList = playlist.Id,
                    PlayListFileType = value.PlayListFileType,
                    FileData = fileMS.ToArray(),
                    FileName = file.FileName,
                    FileMimeType = file.ContentType,
                    FileSize = file.Length
                });
            }
            return Ok(new ApiReturnItem<PlaylistFileResult> { Item = result, Success = true });
        }

        /// <summary>
        /// Deleta um Item (PlaylistFile) de uma playlist.
        /// </summary>
        [HttpDelete("{idBusiness}/{id}")]
        [Authorize("Bearer")]
        [CustomAuthorize(AppSliderRoles.WritePlaylist)]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ApiReturnItem<PlaylistFileResult>))]
        public async Task<IActionResult> Delete(Guid idBusiness, Guid id)
        {
            var result = await _playlistFileService.ProcessDelete(idBusiness, id);

            return Ok(new ApiReturnItem<Boolean> { Item = result, Success = true });
        }
    }
}