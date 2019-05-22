using System;
using Newtonsoft.Json;

namespace AppSlider.Application.Login.Messages
{
    public class LoginResponse
    {
        [JsonProperty("sucesso")]
        public Boolean Success { get; set; }

        [JsonProperty("data_criacao")]
        public String CreationData { get; set; }

        [JsonProperty("data_expiracao")]
        public String ExpirationData { get; set; }

        [JsonProperty("token")]
        public String Token { get; set; }

        [JsonProperty("usuario")]
        public String User { get; set; }

        [JsonProperty("perfil_usuario")]
        public String UserProfile { get; set; }
    }
}