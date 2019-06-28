using Newtonsoft.Json;
using System;

namespace AppSlider.Application.Playlist.Commands
{
    public class PlaylistUpdateCommand
    {
        [JsonProperty("id")]
        public virtual Guid Id { get; set; }

        [JsonProperty("nome")]
        public virtual String Name { get; set; }

        [JsonProperty("ativa")]
        public virtual String Active { get; set; }

        [JsonProperty("data_expiracao")]
        public virtual DateTime Expirate { get; set; }

        [JsonProperty("id_franquia")]
        public virtual Guid FranchiseId { get; set; }
    }
}
