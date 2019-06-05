using System;
using Newtonsoft.Json;

namespace AppSlider.Application.Category.Results
{
    public class CategoryResult
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("nome")]
        public String Name { get; private set; }

        [JsonProperty("descricao")]
        public String Description { get; private set; }
        
        public static explicit operator CategoryResult(Domain.Entities.Categories.Category category)
        {
            return category == null ? null : new CategoryResult
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public static explicit operator Domain.Entities.Categories.Category(CategoryResult category)
        {
            return category == null ? null : new Domain.Entities.Categories.Category(
                category.Id,
                category.Name,
                category.Description
            );
        }
    }
}