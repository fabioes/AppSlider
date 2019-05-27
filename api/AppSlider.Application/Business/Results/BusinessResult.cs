using System;
using Newtonsoft.Json;

namespace AppSlider.Application.Business.Results
{
    public class BusinessResult
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

        public static explicit operator BusinessResult(Domain.Entities.Business.BusinessEntity b)
        {
            return new BusinessResult();
        }

        public static explicit operator Domain.Entities.Business.BusinessEntity(BusinessResult b)
        {
            return new Domain.Entities.Business.BusinessEntity();
        }
    }
}