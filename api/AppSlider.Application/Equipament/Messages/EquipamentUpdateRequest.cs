using System;
using Newtonsoft.Json;

namespace AppSlider.Application.Equipament.Messages
{
    public class EquipamentUpdateRequest
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("nome")]
        public String Name { get; set; }

        [JsonProperty("descricao")]
        public String Description { get; set; }

        [JsonProperty("mac_address")]
        public String MacAddress { get; set; }

        [JsonProperty("id_franquia")]
        public Guid IdFranchise { get; set; }

        [JsonProperty("id_estabelecimento")]
        public Guid? IdEstablishment { get; set; }

        [JsonProperty("id_playlist")]
        public Guid? IdPlaylist { get; set; }

        [JsonProperty("ativo")]
        public Boolean Active { get; set; }
    }
}