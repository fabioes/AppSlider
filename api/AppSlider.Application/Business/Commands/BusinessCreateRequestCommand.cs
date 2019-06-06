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
        public Guid? IdCategory { get; set; }

        [JsonProperty("nome")]
        public String Name { get; set; }

        [JsonProperty("descricao")]
        public String Description { get; set; }

        [JsonProperty("id_logo")]
        public Guid? IdLogo { get; set; }

        [JsonProperty("contato_nome")]
        public String ContactName { get; set; }

        [JsonProperty("contato_email")]
        public String ContactEmail { get; set; }

        [JsonProperty("contato_telefone")]
        public String ContactPhone { get; set; }

        [JsonProperty("contato_endereco")]
        public String ContactAddress { get; set; }

        [JsonProperty("data_expiracao")]
        public DateTime? ExpirationDate { get; set; }
        
        [JsonProperty("ativo")]
        public Boolean Active { get; set; }
    }
}
