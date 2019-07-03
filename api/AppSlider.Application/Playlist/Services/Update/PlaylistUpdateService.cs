using AppSlider.Application.Playlist.Commands;
using AppSlider.Application.Playlist.Results;
using AppSlider.Domain;
using AppSlider.Domain.Entities.PlayLists;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Playlist.Services.Update
{
    public class PlaylistUpdateService : IPlaylistUpdateService
    {
        private readonly IPlaylistRepository playlistRepository; 
        
        public PlaylistUpdateService(IPlaylistRepository playlistRepository)
        {
            this.playlistRepository = playlistRepository;
        }

        public async Task<PlaylistResult> Process(PlaylistUpdateCommand command)
        {
            PlaylistUpdateValidations(command);

            var businessType = new Domain.Entities.PlayLists.Playlist(command.Id, command.Name, command.Active, command.Expirate, command.FranchiseId, false);

            await playlistRepository.Update(businessType);

            var returnBusinessType = (PlaylistResult)businessType;

            return returnBusinessType;
        }


        private void PlaylistUpdateValidations(PlaylistUpdateCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados da Playlist!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.Name))
                    messageValidations.Add("Na atualização de uma Playlist o 'Nome' é obrigatório!");
            }
            
            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na atualização da Playlist {command?.Name ?? ""}", messageValidations, "PlaylistUpdateService - Validations");
            }
        }
    }
}
