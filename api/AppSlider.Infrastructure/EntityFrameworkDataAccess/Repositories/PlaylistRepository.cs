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

        public async Task<PlayList> Add(PlayList playlist)
        {
            await _context.PlayLists.AddAsync(playlist);
            await _context.SaveChangesAsync();

            return playlist;
        }

        public async Task<bool> Delete(PlayList playlist)
        {
            _context.PlayLists.Remove(playlist);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<PlayList> Get(Guid id)
        {
            var playList = await _context.PlayLists.FindAsync(id);

            return playList;
        }

        public async Task<ICollection<PlayList>> GetAll()
        {
            var playLists = await _context.PlayLists.ToListAsync();

            return playLists;
        }

        public async Task<List<PlayList>> GetByFranchise(Guid franchiseId)
        {
            var playlists = await _context.PlayLists.Where(w => w.FranchiseId == franchiseId).ToListAsync();
            return playlists;
        }

        public async Task<PlayList> Update(PlayList playlist)
        {
            var playlistAux = await _context.PlayLists.FindAsync(playlist.Id);
            playlist.PLayListFiles = playlistAux.PLayListFiles;

            DetachPlaylist(playlistAux);

            _context.PlayLists.Update(playlist);
            await _context.SaveChangesAsync();

            return playlist;
        }

        public void DetachPlaylist(PlayList playlist)
        {
            _context.Entry(playlist).State = EntityState.Detached;
        }


        public async Task<PlayListFile> AddPlaylistItem(PlayListFile playListFile)
        {
            var playlist = await Get(playListFile.IdPlayList);

            playlist.PLayListFiles = playlist.PLayListFiles ?? new List<PlayListFile>();
            playlist.PLayListFiles.Add(playListFile);

            _context.SaveChanges();

            return playListFile;
        }

        public async Task<PlayList> DeletePlaylistItem(Guid playListId, Guid playListFileId)
        {
            var playlist = await Get(playListId);

            var playlistFile = playlist?.PLayListFiles?.FirstOrDefault(f => f.Id == playListFileId);

            if (playlistFile == null) return null;

            var file = await _context.Files.FindAsync(playlistFile.IdFile);

            if (file != null)
                _context.Entry(file).State = EntityState.Deleted;

            playlist.PLayListFiles?.ToList()?.Remove(playlistFile);

            _context.SaveChanges();

            return playlist;
        }
        
    }
}
