using AppSlider.Domain.Entities.Files;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSlider.Domain.Entities.PlayLists
{
    public class PlaylistFile : Entity, IAggregateRoot
    {
        public virtual Guid IdPlayList { get; protected set; }
        public virtual PlaylistFileType PlaylistFileType { get; set; }

        [Required]
        public virtual Guid IdFile { get; protected set; }
        public virtual Int16 Duration { get; set; }

        [ForeignKey("IdPlayList")]
        public virtual Playlist Playlist { get; set; }

        [ForeignKey("IdFile")]
        public virtual File File { get; set; }

        public PlaylistFile(Guid id, Guid idPlayList, PlaylistFileType playlistFileType, Guid idFile, short duration) : this()
        {
            Id = id;
            IdPlayList = idPlayList;
            PlaylistFileType = playlistFileType;
            IdFile = idFile;
            Duration = duration;
        }

        public PlaylistFile(Guid idPlayList, PlaylistFileType playListFileType, Guid idFile, short duration) : this()
        {
            IdPlayList = idPlayList;
            PlaylistFileType = playListFileType;
            IdFile = idFile;
            Duration = duration;
        }

        public PlaylistFile()
        {
        }
    }
}
