using AppSlider.Application.PlaylistFile.Commands;
using AppSlider.Application.PlaylistFile.Results;
using AppSlider.Domain;
using AppSlider.Domain.Entities.PlayLists;
using AppSlider.Domain.Repositories;
using AppSlider.Utils.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.PlaylistFile.Services
{
    public class PlaylistFileService : IPlaylistFileService
    {
        private readonly IPlaylistRepository playlistRepository;
        private readonly IFileRepository fileRepository;

        public PlaylistFileService(IPlaylistRepository playlistRepository, IFileRepository fileRepository)
        {
            this.playlistRepository = playlistRepository;
            this.fileRepository = fileRepository;
        }

        public async Task<PlaylistFileResult> ProcessCreate(PlaylistFileCommand command)
        {
            PlaylistFileCreateValidations(command);

            var playlist = await playlistRepository.Get(command.IdPlayList);

            if (playlist == null)
                throw new Exception("Informe um Id para alguma Playlist válida!");


            var file = await fileRepository.Add(new Domain.Entities.Files.File(command.FileName, command.FileData, command.FileMimeType, command.FileSize));

            var playlistFile = await playlistRepository.AddPlaylistItem(new Domain.Entities.PlayLists.PlaylistFile(command.IdPlayList, EnumUtils.GetValueFromDescription<PlaylistFileType>(command.PlayListFileType), file.Id, command.Duration));

            var returnPlaylistFile = (PlaylistFileResult)playlistFile;

            return returnPlaylistFile;
        }

        public async Task<Boolean> ProcessDelete(Guid playlistId, Guid playlistFileId)
        {            
            await playlistRepository.DeletePlaylistItem(playlistId, playlistFileId);

            return true;
        }


        private void PlaylistFileCreateValidations(PlaylistFileCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados do PlaylistFile!");
            }
            else
            {
                
            }
            
            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na inclusão de um Item da Playlist", messageValidations, "PlaylistFileService - PlaylistFileCreateValidations");
            }
        }
    }
}
