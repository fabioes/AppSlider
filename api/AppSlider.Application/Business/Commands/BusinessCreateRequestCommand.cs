using AppSlider.Utils.Cripto;
using Newtonsoft.Json;
using System;

namespace AppSlider.Application.Business.Commands
{
    public class BusinessCreateRequestCommand
    {
        [JsonProperty("id_pai")]
        public Guid? IdFather { get; set; }

        [JsonProperty("id_tipo")]
        public Guid IdType { get; set; }

        [JsonProperty("id_categoria")]
        public Guid IdCategory { get; set; }

        [JsonProperty("nome")]
        public String Name { get; set; }

        [JsonProperty("descricao")]
        public String Description { get; set; }

        [JsonProperty("id_logo")]
        public Guid? IdLogo { get; set; }

        [JsonProperty("nome_contato")]
        public String ContactName { get; set; }

        [JsonProperty("email_contato")]
        public String ContactEmail { get; set; }

        [JsonProperty("phone_contato")]
        public String ContactPhone { get; set; }

        [JsonProperty("endereco_contato")]
        public String ContactAddress { get; set; }

        [JsonProperty("data_expiracao")]
        public DateTime ExpirationDate { get; set; }
        
        [JsonProperty("ativo")]
        public Boolean Active { get; set; }
    }
}
