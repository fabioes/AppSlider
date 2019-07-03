using AppSlider.Application.Playlist.Commands;
using AppSlider.Application.Playlist.Results;
using System.Threading.Tasks;

namespace AppSlider.Application.Playlist.Services.Update
{
    public interface IPlaylistUpdateService
    {
        Task<PlaylistResult> Process(PlaylistUpdateCommand command);
    }
}
