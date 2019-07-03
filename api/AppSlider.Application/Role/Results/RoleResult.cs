using System;
using Newtonsoft.Json;

namespace AppSlider.Application.Role.Results
{
    public class RoleResult
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("nome")]
        public String Name { get; private set; }

        [JsonProperty("descricao")]
        public String Description { get; private set; }

        public static explicit operator RoleResult(Domain.Entities.Roles.Role r)
        {
            return new RoleResult
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            };
        }
    }
}