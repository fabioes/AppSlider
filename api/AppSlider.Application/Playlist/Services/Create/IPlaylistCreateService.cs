using AppSlider.Application.Playlist.Commands;
using AppSlider.Application.Playlist.Results;
using System.Threading.Tasks;

namespace AppSlider.Application.Playlist.Services.Create
{
    public interface IPlaylistCreateService
    {
        Task<PlaylistResult> Process(PlaylistCreateCommand command);
    }
}
