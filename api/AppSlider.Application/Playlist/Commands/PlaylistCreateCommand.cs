using Newtonsoft.Json;
using System;

namespace AppSlider.Application.Playlist.Commands
{
    public class PlaylistCreateCommand
    {
        [JsonProperty("nome")]
        public virtual string Name { get; set; }

        [JsonProperty("ativa")]
        public virtual bool Active { get; set; }

        [JsonProperty("data_expiracao")]
        public virtual DateTime Expirate { get; set; }

        [JsonProperty("id_business")]
        public virtual Guid BusinessId { get; set; }
    }
}
