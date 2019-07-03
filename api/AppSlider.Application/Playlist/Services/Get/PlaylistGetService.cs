using AppSlider.Application.Playlist.Results;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSlider.Application.Playlist.Services.Get
{
    public class PlaylistGetService : IPlaylistGetService
    {
        private readonly IPlaylistRepository playlistRepository;

        public PlaylistGetService(IPlaylistRepository playlistRepository)
        {
            this.playlistRepository = playlistRepository;
        }

        public async Task<PlaylistResult> Get(Guid id)
        {
            var playlist = await playlistRepository.Get(id);

            var returnPlaylist = (PlaylistResult)playlist;

            return returnPlaylist;
        }

        public async Task<List<PlaylistResult>> GetByFranchise(Guid franchiseId)
        {
            var playlists = await playlistRepository.GetByFranchise(franchiseId);

            var returnPlaylists = playlists?.Select(s => (PlaylistResult)s)?.ToList();

            return returnPlaylists;
        }

        public async Task<List<PlaylistResult>> GetAll()
        {
            var playlists = await playlistRepository.GetAll();

            var returnPlaylists = playlists.Select(s => (PlaylistResult)s).ToList();
            
            return returnPlaylists;
        }
    }
}
