using System;
using System.Collections.Generic;
using System.Linq;
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
        public String Profile { get; private set; } = "user";

        [JsonProperty("ativo")]
        public Boolean Active { get; private set; }

        [JsonProperty("bloqueado")]
        public Boolean Blocked { get; private set; }

        [JsonProperty("nome")]
        public String Name { get; private set; }

        [JsonProperty("email")]
        public String Email { get; private set; }

        [JsonProperty("franquias")]
        public List<String> Franchises { get; private set; }

        [JsonProperty("roles")]
        public List<String> Roles { get; private set; }

        [JsonProperty("roles_names")]
        public List<String> RolesNames { get; private set; }

        public void SetRolesNames(List<String> names)
        {
            RolesNames = names;
        }

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
                Franchises = String.IsNullOrEmpty(u.Franchises) ? null : u.Franchises.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList(),
                Roles = String.IsNullOrEmpty(u.Roles) ? null : u.Roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList(),
                Blocked = u.Blocked
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
                u.Franchises != null ? String.Join(",", u.Franchises) : null,
                u.Roles != null ? String.Join(",", u.Roles) : null,
                u.Active,
                u.Blocked
            );
        }
    }
}