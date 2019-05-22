using System;
using Newtonsoft.Json;

namespace AppSlider.Application.Login.Messages
{
    public class LoginRequest
    {
        [JsonProperty("login")]
        public String Username { get; set; }

        [JsonProperty("senha")]
        public String Password { get; set; }
    }
}