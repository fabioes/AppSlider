using System;
using System.Collections.Generic;
using System.Linq;
using AppSlider.Application.Category.Results;
using AppSlider.Application.Equipament.Results;
using AppSlider.Application.TypeBusiness.Results;
using Newtonsoft.Json;

namespace AppSlider.Application.Business.Results
{
    public class BusinessResult
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

        [JsonProperty("bloqueado")]
        public virtual Boolean Blocked { get; set; }

        [JsonProperty("file")]
        public virtual byte[] File { get; set; }

        [JsonProperty("categoria")]
        public virtual CategoryResult Category { get; set; }

        [JsonProperty("tipo")]
        public virtual TypeBusinessResult Type { get; set; }

        //[JsonProperty("logo")]
        //public virtual FileResult Logo { get; set; }

        [JsonProperty("pai")]
        public virtual BusinessResult BusinessEntityFather { get; set; }

        [JsonProperty("filhos")]
        public virtual IList<BusinessResult> ChildrenBusinessEntity { get; set; }

        [JsonProperty("equipaments")]
        public virtual IList<EquipamentResult> Equipaments { get; set; }

        public static explicit operator BusinessResult(Domain.Entities.Business.BusinessEntity b)
        {
            return b == null ? null : new BusinessResult
            {
                Active = b.Active,
                //BusinessEntityFather = (BusinessResult)b.BusinessEntityFather,
                Category = (CategoryResult)b.Category,
                ChildrenBusinessEntity = b.ChildrenBusinessEntity?.Select(s => (BusinessResult)s)?.ToList(),
                ContactAddress = b.ContactAddress,
                ContactEmail = b.ContactEmail,
                ContactName = b.ContactName,
                ContactPhone = b.ContactPhone,
                ContactCity = b.ContactCity,
                Description = b.Description,
                ExpirationDate = b.ExpirationDate,
                Id = b.Id,
                IdCategory = b.IdCategory,
                IdFather = b.IdFather,
                IdLogo = b.IdLogo,
                IdType = b.IdType,
                Name = b.Name,
                CNPJ = b.CNPJ,
                Type = (TypeBusinessResult)b.Type,
                Blocked = b.Blocked,
                File = b.File,
                //ChildrenBusinessEntity = b.ChildrenBusinessEntity as List<BusinessResult>

            };
        }

        public static explicit operator Domain.Entities.Business.BusinessEntity(BusinessResult b)
        {
            return b == null ? null : new Domain.Entities.Business.BusinessEntity(b.Id, b.IdFather, b.IdType, b.IdCategory, b.Name, b.CNPJ, b.Description, b.IdLogo, b.ContactName, b.ContactEmail, b.ContactPhone, b.ContactAddress,b.ContactCity, b.ExpirationDate, b.Active, b.Blocked);
        }
    }
}