using AppSlider.Domain.Entities.PlayLists;
using AppSlider.Utils.Enum;
using Newtonsoft.Json;
using System;

namespace AppSlider.Application.PlaylistFile.Results
{
    public class PlaylistFileResult
    {
        [JsonProperty("id")]
        public virtual Guid Id{ get; set; }

        [JsonProperty("id_playlist")]
        public virtual Guid IdPlayList { get; set; }

        [JsonProperty("tipo")]
        public virtual String PlayListFileType { get; set; }

        [JsonProperty("id_arquivo")]
        public virtual Guid IdFile { get; protected set; }

        [JsonProperty("tempo_duracao")]
        public virtual Int16 Duration { get; set; }

        public static explicit operator PlaylistFileResult(Domain.Entities.PlayLists.PlaylistFile playlistFile)
        {
            return playlistFile == null ? null : new PlaylistFileResult
            {
                Id = playlistFile.Id,
                Duration = playlistFile.Duration,
                IdFile = playlistFile.IdFile,
                IdPlayList = playlistFile.IdPlayList,
                PlayListFileType = EnumUtils.GetDescription(playlistFile.PlaylistFileType)
            };
        }

        public static explicit operator Domain.Entities.PlayLists.PlaylistFile(PlaylistFileResult playlistFile)
        {
            return playlistFile == null ? null : new Domain.Entities.PlayLists.PlaylistFile(
                playlistFile.Id,
                playlistFile.IdPlayList,
                EnumUtils.GetValueFromDescription<PlaylistFileType>(playlistFile.PlayListFileType),
                playlistFile.IdFile,
                playlistFile.Duration);
        }
    }
}
