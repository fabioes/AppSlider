using AppSlider.Domain.Entities.PlayLists;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSlider.Application.Playlist.Commands
{
    public class PlaylistCreateCommand
    {
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
