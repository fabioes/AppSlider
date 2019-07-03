using AppSlider.Domain.Entities.PlayLists;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSlider.Application.Playlist.Messages
{
    public class PlaylistCreateRequest
    {
        [JsonProperty("nome")]
        public virtual String Name { get; set; }

        [JsonProperty("ativa")]
        public virtual Boolean Active { get; set; }

        [JsonProperty("data_expiracao")]
        public virtual DateTime? Expirate { get; set; }

        [JsonProperty("id_franquia")]
        public virtual Guid FranchiseId { get; set; }
    }
}
