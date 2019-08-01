namespace AppSlider.Domain.Repositories
{
    using AppSlider.Domain.Entities.PlayLists;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPlaylistRepository
    {
        Task<Playlist> Get(Guid id);
        Task<Playlist> GetMidiaFoneUtilitiesPlaylist();
        Task<ICollection<Playlist>> GetAll();
        Task<ICollection<Playlist>> GetByFranchise(Guid franshiseId);
        Task<Playlist> GetByBusiness(Guid businessId);
        Task<Playlist> Add(Playlist playList);
        Task<Playlist> Update(Playlist playList);
        Task<PlaylistFile> AddPlaylistItem(PlaylistFile playListFile);
        Task<Playlist> DeletePlaylistItem(Guid businessId, Guid playListFileId);
        Task<Boolean> Delete(Playlist playList);
        void DetachPlaylist(Playlist playList);
    }
}
