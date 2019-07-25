using System;
using Newtonsoft.Json;

namespace AppSlider.Application.Category.Messages
{
    public class CategoryUpdateRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public String Name { get; set; }

        [JsonProperty("descricao")]
        public String Description { get; set; }
    }
}