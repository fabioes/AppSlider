using AppSlider.Application.Equipament.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AppSlider.Application.Business.Commands
{
    public class BusinessCreateRequestCommand
    {
        public Guid? Id { get; set; }

        [JsonProperty("id_pai")]
        public Guid? IdFather { get; set; }

        [JsonProperty("id_tipo")]
        public int IdType { get; set; }

        [JsonProperty("id_categoria")]
        public int? IdCategory { get; set; }

        [JsonProperty("nome")]
        public String Name { get; set; }

        [JsonProperty("CNPJ")]
        public long? CNPJ { get; set; }

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

        [JsonProperty("contato_cidade")]
        public String ContactCity { get; set; }

        [JsonProperty("data_expiracao")]
        public DateTime? ExpirationDate { get; set; }

        [JsonProperty("ativo")]
        public Boolean Active { get; set; }

        [JsonProperty("file")]
        public byte[] File { get; set; }

        [JsonProperty("filhos")]
        public List<BusinessCreateRequestCommand> Children { get; set; }
        [JsonProperty("equipaments")]
        public virtual List<EquipamentUpdateCommand> Equipaments { get; set; }
    }
}
