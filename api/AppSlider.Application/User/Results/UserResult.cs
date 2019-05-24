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

        [JsonProperty("franquias")]
        public String Franchises { get; private set; }

        [JsonProperty("roles")]
        public String Roles { get; private set; }

        public static explicit operator UserResult(Domain.Entities.Users.User u)
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
                Franchises = u.Franchises,
                Roles = u.Roles
            };
        }

        public static explicit operator Domain.Entities.Users.User(UserResult u)
        {
            return new Domain.Entities.Users.User(
                u.Id,
                u.Name,
                u.Username,
                u.Password,
                u.Profile,
                u.Email,
                u.Franchises,
                u.Roles,
                u.Active
            );
        }
    }
}