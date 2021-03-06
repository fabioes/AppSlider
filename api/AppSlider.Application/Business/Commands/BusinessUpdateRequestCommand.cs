using AppSlider.Application.Equipament.Commands;
using AppSlider.Utils.Cripto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AppSlider.Application.Business.Commands
{
    public class BusinessUpdateRequestCommand
    {
        [JsonProperty("id")]
        public virtual Guid Id { get; set; }

        [JsonProperty("id_pai")]
        public virtual Guid? IdFather { get; set; }

        [JsonProperty("id_tipo")]
        public virtual int IdType { get; set; }

        [JsonProperty("id_categoria")]
        public virtual int? IdCategory { get; set; }

        [JsonProperty("nome")]
        public virtual String Name { get; set; }

        [JsonProperty("CNPJ")]
        public virtual long? CNPJ { get; set; }

        [JsonProperty("descricao")]
        public virtual String Description { get; set; }

        [JsonProperty("id_logo")]
        public virtual Guid? IdLogo { get; set; }

        [JsonProperty("contato_nome")]
        public virtual String ContactName { get; set; }

        [JsonProperty("contato_email")]
        public virtual String ContactEmail { get; set; }

        [JsonProperty("contato_telefone")]
        public virtual String ContactPhone { get; set; }

        [JsonProperty("contato_endereco")]
        public virtual String ContactAddress { get; set; }
        [JsonProperty("contato_cidade")]
        public virtual String ContactCity { get; set; }

        [JsonProperty("data_expiracao")]
        public virtual DateTime? ExpirationDate { get; set; }

        [JsonProperty("ativo")]
        public virtual Boolean Active { get; set; }

        [JsonIgnore]
        public virtual byte[] File{ get; set; }

        [JsonProperty("filhos")]
        public virtual List<BusinessUpdateRequestCommand> Children { get; set; }

        [JsonProperty("equipaments")]
        public virtual List<EquipamentUpdateCommand> Equipaments { get; set; }
    }
}
