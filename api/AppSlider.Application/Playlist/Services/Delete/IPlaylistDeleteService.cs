using System;
using System.Threading.Tasks;

namespace AppSlider.Application.Playlist.Services.Delete
{
    public interface IPlaylistDeleteService
    {
        Task<Boolean> Process(Guid id);
    }
}
