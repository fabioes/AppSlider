using System;
using Newtonsoft.Json;

namespace AppSlider.Application.User.Messages
{ 
    public class UserResetPasswordRequest
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("senha")]
        public String Password { get; set; }
    }
}