using AppSlider.Application.PlaylistFile.Results;
using AppSlider.Domain.Entities.PlayLists;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppSlider.Application.Playlist.Results
{
    public class PlaylistResult
    {
        [JsonProperty("id")]
        public virtual Guid Id { get; set; }

        [JsonProperty("nome")]
        public virtual String Name { get; set; }

        [JsonProperty("ativa")]
        public virtual Boolean Active { get; set; }

        [JsonProperty("bloqueada")]
        public virtual Boolean Blocked { get; set; }

        [JsonProperty("data_expiracao")]
        public virtual DateTime Expirate { get; set; }

        [JsonProperty("id_franquia")]
        public virtual Guid FranchiseId { get; set; }

        [JsonProperty("playlist_itens")]
        public virtual IList<PlaylistFileResult> PlaylistFiles { get; set; }

        public static explicit operator PlaylistResult(PlayList playlist)
        {
            return playlist == null ? null : new PlaylistResult
            {
                Id = playlist.Id,
                Name = playlist.Name,
                Active = playlist.Active,
                PlaylistFiles = playlist.PLayListFiles?.Select(s => (PlaylistFileResult)s)?.ToList(),
                Expirate = playlist.Expirate,
                Blocked = playlist.Blocked,
                FranchiseId = playlist.FranchiseId
            };
        }

        public static explicit operator PlayList(PlaylistResult playlist)
        {
            if (playlist == null) return null;


            var returnPlaylist = new PlayList(
                playlist.Id,
                playlist.Name,
                playlist.Active,
                playlist.Expirate,
                playlist.FranchiseId,
                playlist.Blocked
            );

            returnPlaylist.PLayListFiles = playlist.PlaylistFiles?.Select(s => (PlayListFile)s).ToList();

            return returnPlaylist;
        }
    }
}
