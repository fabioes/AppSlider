using System;
using System.Collections.Generic;
using System.Linq;
using AppSlider.Application.Category.Results;
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
        public virtual Guid IdType { get; set; }

        [JsonProperty("id_categoria")]
        public virtual Guid? IdCategory { get; set; }

        [JsonProperty("nome")]
        public virtual String Name { get; set; }

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

        [JsonProperty("data_expiracao")]
        public virtual DateTime ExpirationDate { get; set; }

        [JsonProperty("ativo")]
        public virtual Boolean Active { get; set; }

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

        public static explicit operator BusinessResult(Domain.Entities.Business.BusinessEntity b)
        {
            return b == null ? null : new BusinessResult
            {
                Active = b.Active,
                BusinessEntityFather = (BusinessResult)b.BusinessEntityFather,
                Category = (CategoryResult)b.Category,
                ChildrenBusinessEntity = b.ChildrenBusinessEntity?.Select(s => (BusinessResult)s)?.ToList(),
                ContactAddress = b.ContactAddress,
                ContactEmail = b.ContactEmail,
                ContactName = b.ContactName,
                ContactPhone = b.ContactPhone,
                Description = b.Description,
                ExpirationDate = b.ExpirationDate,
                Id = b.Id,
                IdCategory = b.IdCategory,
                IdFather = b.IdFather,
                IdLogo = b.IdLogo,
                IdType = b.IdType,
                Name = b.Name,
                Type = (TypeBusinessResult)b.Type
            };
        }

        public static explicit operator Domain.Entities.Business.BusinessEntity(BusinessResult b)
        {
            return new Domain.Entities.Business.BusinessEntity(b.Id, b.IdFather, b.IdType, b.IdCategory, b.Name, b.Description, b.IdLogo, b.ContactName, b.ContactEmail, b.ContactPhone, b.ContactAddress, b.ExpirationDate, b.Active);

        }

        
    }
}