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
        public List<Guid> Roles { get; set; }

        [JsonProperty("contratos")]
        public List<Guid> Contracts { get; set; }

        [JsonProperty("perfil")]
        public String Profile { get; set; }

        [JsonProperty("ativo")]
        public Boolean? Active { get; set; }
    }
}