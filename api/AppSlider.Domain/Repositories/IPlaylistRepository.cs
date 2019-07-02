namespace AppSlider.Domain.Repositories
{
    using AppSlider.Domain.Entities.PlayLists;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPlaylistRepository
    {
        Task<PlayList> Get(Guid id);
        Task<PlayList> GetMidiaFoneUtilitiesPlaylist();
        Task<ICollection<PlayList>> GetAll();
        Task<ICollection<PlayList>> GetByFranchise(Guid franshiseId);
        Task<PlayList> Add(PlayList playList);
        Task<PlayList> Update(PlayList playList);
        Task<PlayListFile> AddPlaylistItem(PlayListFile playListFile);
        Task<PlayList> DeletePlaylistItem(Guid playListId, Guid playListFileId);
        Task<Boolean> Delete(PlayList playList);
        void DetachPlaylist(PlayList playList);
    }
}
