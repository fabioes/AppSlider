using System;
using Newtonsoft.Json;

namespace AppSlider.Application.TypeBusiness.Messages
{
    public class TypeBusinessCreateRequest
    {
        [JsonProperty("nome")]
        public String Name { get; set; }

        [JsonProperty("descricao")]
        public String Description { get; set; }
    }
}