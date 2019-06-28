using AppSlider.Application.Playlist.Results;
using System;
using System.Threading.Tasks;

namespace AppSlider.Application.Playlist.Services.Config
{
    public interface IPlaylistConfigService
    {
        Task<PlaylistResult> SwitchActive(Guid id);
                
    }
}
