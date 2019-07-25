using System;
using Newtonsoft.Json;

namespace AppSlider.Application.TypeBusiness.Results
{
    public class TypeBusinessResult
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("nome")]
        public String Name { get; private set; }

        [JsonProperty("descricao")]
        public String Description { get; private set; }

        [JsonProperty("bloqueado")]
        public Boolean Blocked { get; private set; }

        public static explicit operator TypeBusinessResult(Domain.Entities.Business.BusinessType businessType)
        {
            return businessType == null ? null : new TypeBusinessResult
            {
                Id = businessType.Id,
                Name = businessType.Name,
                Description = businessType.Description,
                Blocked = businessType.Blocked
            };
        }

        public static explicit operator Domain.Entities.Business.BusinessType(TypeBusinessResult businessType)
        {
            return businessType == null ? null : new Domain.Entities.Business.BusinessType(
                businessType.Id,
                businessType.Name,
                businessType.Description,
                businessType.Blocked
            );
        }
    }
}