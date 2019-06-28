using AppSlider.Application.PlaylistFile.Commands;
using AppSlider.Application.PlaylistFile.Results;
using System;
using System.Threading.Tasks;

namespace AppSlider.Application.PlaylistFile.Services
{
    public interface IPlaylistFileService
    {
        Task<PlaylistFileResult> ProcessCreate(PlaylistFileCommand command);
        Task<Boolean> ProcessDelete(Guid playlistId, Guid playlistFileId);
    }
}
