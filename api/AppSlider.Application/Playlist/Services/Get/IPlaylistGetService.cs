using AppSlider.Application.Playlist.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Playlist.Services.Get
{
    public interface IPlaylistGetService
    {
        Task<PlaylistResult> Get(Guid id);

        Task<List<PlaylistResult>> GetByFranchise(Guid franchiseId);

        Task<List<PlaylistResult>> GetAll();
    }
}
