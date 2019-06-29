using AppSlider.Application.Playlist.Commands;
using AppSlider.Application.Playlist.Results;
using AppSlider.Application.TypeBusiness.Commands;
using AppSlider.Application.TypeBusiness.Results;
using AppSlider.Domain;
using AppSlider.Domain.Entities.PlayLists;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Playlist.Services.Create
{
    public class PlaylistCreateService : IPlaylistCreateService
    {
        private readonly IPlaylistRepository playlistRepository;
        
        public PlaylistCreateService(IPlaylistRepository playlistRepository)
        {
            this.playlistRepository = playlistRepository;
        }

        public async Task<PlaylistResult> Process(PlaylistCreateCommand command)
        {
            PlaylistCreateValidations(command);

            var playlist = new PlayList(command.Name, command.Active, command.Expirate, command.FranchiseId, false);

            await playlistRepository.Add(playlist);

            var returnUser = (PlaylistResult)playlist;

            return returnUser;
        }


        private void PlaylistCreateValidations(PlaylistCreateCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados da Playlist!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.Name))
                    messageValidations.Add("Na criação de uma Playlist o 'Nome' é obrigatorio!");

                
            }
            
            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na criação da Playlist {command?.Name ?? ""}", messageValidations, "PlaylistCreateService - Validations");
            }
        }
    }
}
