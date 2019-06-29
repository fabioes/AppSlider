using AppSlider.Application.Business.Results;
using AppSlider.Application.Playlist.Results;
using AppSlider.Domain;
using AppSlider.Domain.Entities.Business;
using AppSlider.Domain.Entities.PlayLists;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AppSlider.Application.Playlist.Services.Config
{
    public class PlaylistConfigService : IPlaylistConfigService
    {
        private readonly IPlaylistRepository playlistRepository;

        public PlaylistConfigService(IPlaylistRepository playlistRepository)
        {
            this.playlistRepository = playlistRepository;
        }

        public async Task<PlaylistResult> SwitchActive(Guid id)
        {
            PlylistConfigSwitchActiveValidations(id);

            var playlist = await playlistRepository.Get(id);

            if (playlist == null)
                throw new BusinessException($"Erro na ativação / desativação da Playlist", new List<string> { "Playlist Inexistente!" }, "PlaylistConfigService - Validations");

            var domainPlaylist = new PlayList(playlist.Id, playlist.Name, !playlist.Active, playlist.Expirate, playlist.FranchiseId, playlist.Blocked);

            playlistRepository.DetachPlaylist(playlist);

            await playlistRepository.Update(domainPlaylist);

            var playlistResult = (PlaylistResult)domainPlaylist;

            return playlistResult;
        }

        private void PlylistConfigSwitchActiveValidations(Guid id)
        {
            var messageValidations = new List<String>();

            if (id == new Guid())
            {
                messageValidations.Add("Para ativar / desativar uma Playlist o 'Id' é obrigatorio!");
            }

            if (messageValidations.Count > 0)
            {
                throw new BusinessException("Erro na atualização da Playlist", messageValidations, "PlaylistConfigService - Validations");
            }
        }
    }
}
