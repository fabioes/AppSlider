using AppSlider.Domain.Entities.Files;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSlider.Domain.Entities.PlayLists
{
    public class PlayListFile : Entity, IAggregateRoot
    {
        public virtual Guid IdPlayList { get; protected set; }
        public virtual PlayListFileType PlayListFileType { get; set; }

        [Required]
        public virtual Guid IdFile { get; protected set; }
        public virtual Int16 Duration { get; set; }

        [ForeignKey("IdPlayList")]
        public virtual PlayList PlayList { get; set; }

        [ForeignKey("IdFile")]
        public virtual File File { get; set; }

        public PlayListFile(Guid id, Guid idPlayList, PlayListFileType playListFileType, Guid idFile, short duration) : this()
        {
            Id = id;
            IdPlayList = idPlayList;
            PlayListFileType = playListFileType;
            IdFile = idFile;
            Duration = duration;
        }

        public PlayListFile(Guid idPlayList, PlayListFileType playListFileType, Guid idFile, short duration) : this()
        {
            IdPlayList = idPlayList;
            PlayListFileType = playListFileType;
            IdFile = idFile;
            Duration = duration;
        }

        public PlayListFile()
        {
        }
    }
}
