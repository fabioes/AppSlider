using System;
using Newtonsoft.Json;

namespace AppSlider.Application.Business.Messages
{
    public class BusinessUpdateRequest
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("login")]
        public String Username { get; set; }

        [JsonProperty("nome")]
        public String Name { get; set; }

        [JsonProperty("senha")]
        public String Password { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("roles")]
        public String Roles { get; set; }

        [JsonProperty("franquias")]
        public String Franchises { get; set; }

        [JsonProperty("perfil")]
        public String Profile { get; set; }

        [JsonProperty("ativo")]
        public Boolean? Active { get; set; }
    }
}