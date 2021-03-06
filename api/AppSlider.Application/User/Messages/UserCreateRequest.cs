using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppSlider.Application.User.Messages
{
    public class UserCreateRequest
    {
        [JsonProperty("nome")]
        public String Name { get; set; }

        [JsonProperty("login")]
        public String Username { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("senha")]
        public String Password { get; set; }

        [JsonProperty("roles")]
        public List<String> Roles { get; set; }

        [JsonProperty("franquias")]
        public List<String> Franchises { get; set; }

        [JsonProperty("perfil")]
        public String Profile { get; set; } = "user";

        [JsonProperty("ativo")]
        public Boolean? Active { get; set; }
    }
}