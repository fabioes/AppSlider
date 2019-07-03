using System;

namespace AppSlider.Application.PlaylistFile.Commands
{
    public class PlaylistFileCommand
    {
        public virtual Guid IdPlayList { get; set; }
        public virtual String PlayListFileType { get; set; }
        public virtual Int16 Duration { get; set; }

        #region File
        public virtual String FileName { get; set; }
        public virtual Byte[] FileData { get; set; }
        public virtual String FileMimeType { get; set; }
        public virtual Int64 FileSize { get; set; }
        #endregion
    }
}
