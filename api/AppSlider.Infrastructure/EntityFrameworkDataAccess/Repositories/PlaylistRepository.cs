namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using AppSlider.Domain.Repositories;
    using AppSlider.Domain.Entities.PlayLists;
    using System.Linq;

    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly Context _context;

        public PlaylistRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Playlist> Add(Playlist playlist)
        {
            await _context.PlayLists.AddAsync(playlist);
            await _context.SaveChangesAsync();

            return playlist;
        }

        public async Task<bool> Delete(Playlist playlist)
        {
            _context.PlayLists.Remove(playlist);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Playlist> Get(Guid id)
        {
            var playList = await _context.PlayLists.FindAsync(id);

            return playList;
        }
        
        public async Task<Playlist> GetMidiaFoneUtilitiesPlaylist()
        {
            var playList = await _context.PlayLists.Include(i => i.PlaylistFiles).FirstOrDefaultAsync(f => f.Blocked);

            return playList;
        }

        public async Task<ICollection<Playlist>> GetAll()
        {
            var playLists = await _context.PlayLists.ToListAsync();

            return playLists;
        }

        public async Task<ICollection<Playlist>> GetByFranchise(Guid franchiseId)
        {
            var playlists = await _context.PlayLists.Where(w => w.BusinessId == franchiseId).ToListAsync();
            return playlists;
        }
        public async Task<Playlist> GetByBusiness(Guid businessId)
        {
            var playlist = await _context.PlayLists.FirstOrDefaultAsync(w => w.BusinessId == businessId);
            return playlist;
        }

        public async Task<Playlist> Update(Playlist playlist)
        {
            var playlistAux = await _context.PlayLists.FindAsync(playlist.Id);
            playlist.PlaylistFiles = playlistAux.PlaylistFiles;

            DetachPlaylist(playlistAux);

            //_context.DetachLocalIfExists(playlist);

            _context.PlayLists.Update(playlist);
            await _context.SaveChangesAsync();

            return playlist;
        }

        public void DetachPlaylist(Playlist playlist)
        {
            _context.Entry(playlist).State = EntityState.Detached;
        }


        public async Task<PlaylistFile> AddPlaylistItem(PlaylistFile playListFile)
        {
            var playlist = await Get(playListFile.IdPlayList);

            playlist.PlaylistFiles = playlist.PlaylistFiles ?? new List<PlaylistFile>();
            playlist.PlaylistFiles.Add(playListFile);

            _context.SaveChanges();

            return playListFile;
        }

        public async Task<Playlist> DeletePlaylistItem(Guid businessId, Guid playListFileId)
        {
            var playlist = await _context.PlayLists.FirstOrDefaultAsync(x => x.BusinessId == businessId);

            var playlistFile = playlist?.PlaylistFiles?.FirstOrDefault(f => f.Id == playListFileId);

            if (playlistFile == null) return null;

            var file = await _context.Files.FindAsync(playlistFile.IdFile);

            if (file != null)
                _context.Entry(file).State = EntityState.Deleted;

            playlist.PlaylistFiles?.ToList()?.Remove(playlistFile);

            _context.SaveChanges();

            return playlist;
        }
        
    }
}
