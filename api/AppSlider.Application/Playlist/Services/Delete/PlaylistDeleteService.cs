using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Playlist.Services.Delete
{
    public class PlaylistDeleteService : IPlaylistDeleteService
    {
        private readonly IPlaylistRepository playlistRepository;
        
        public PlaylistDeleteService(IPlaylistRepository playlistRepository)
        {
            this.playlistRepository = playlistRepository;            
        }

        public async Task<Boolean> Process(Guid id)
        {
            PlaylistDeleteValidations(id);

            var businessType = await playlistRepository.Get(id);
            
            if (businessType == null)
                throw new BusinessException("Informe um Id de uma Playlist válida!");

            await playlistRepository.Delete(businessType);

            return true;
        }


        private void PlaylistDeleteValidations(Guid id)
        {
            var messageValidations = new List<String>();

            if (id == new Guid())
            {
                messageValidations.Add("Favor informar o Id da Playlist que deseja excluir!");
            }
            
            if(messageValidations.Count > 0)
                throw new BusinessException($"Erro na deleção da Playlist.", messageValidations, "PlaylistDeleteService - Validations");
        }
    }
}
