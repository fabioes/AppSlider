using System;
using Newtonsoft.Json;

namespace AppSlider.Application.User.Results
{
    public class UserResult
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("login")]
        public String Username { get; private set; }

        [JsonProperty("senha")]
        public String Password { get; private set; }

        [JsonProperty("perfil")]
        public String Profile { get; private set; }

        [JsonProperty("ativo")]
        public Boolean Active { get; private set; }

        [JsonProperty("nome")]
        public String Name { get; private set; }

        [JsonProperty("email")]
        public String Email { get; private set; }

        public static explicit operator UserResult(Domain.Users.User u)
        {
            return new UserResult
            {
                Active = u.Active,
                Id = u.Id,
                Password = u.Password,
                Profile = u.Profile,
                Username = u.Username,
                Email = u.Email,
                Name = u.Name,
            };
        }
    }
}