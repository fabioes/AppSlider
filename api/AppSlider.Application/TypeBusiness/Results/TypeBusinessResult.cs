using System;
using Newtonsoft.Json;

namespace AppSlider.Application.TypeBusiness.Results
{
    public class TypeBusinessResult
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("nome")]
        public String Name { get; private set; }

        [JsonProperty("descricao")]
        public String Description { get; private set; }
        
        public static explicit operator TypeBusinessResult(Domain.Entities.Business.BusinessType businessType)
        {
            return new TypeBusinessResult
            {
                Id = businessType.Id,
                Name = businessType.Name,
                Description = businessType.Description
            };
        }

        public static explicit operator Domain.Entities.Business.BusinessType(TypeBusinessResult category)
        {
            return new Domain.Entities.Business.BusinessType(
                category.Id,
                category.Name,
                category.Description
            );
        }
    }
}