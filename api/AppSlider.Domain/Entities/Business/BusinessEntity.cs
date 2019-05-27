using AppSlider.Domain.Entities.Categories;
using AppSlider.Domain.Entities.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSlider.Domain.Entities.Business
{
    public class BusinessEntity : Entity, IAggregateRoot
    {
        public virtual Guid? IdFather { get; protected set; }
        public virtual Guid IdType { get; protected set; }
        public virtual Guid IdCategory { get; protected set; }
        public virtual String Name { get; protected set; }
        public virtual String Description { get; protected set; }
        public virtual Guid? IdLogo { get; protected set; }
        public virtual String ContactName { get; protected set; }
        public virtual String ContactEmail { get; protected set; }
        public virtual String ContactPhone { get; protected set; }
        public virtual String ContactAddress { get; protected set; }
        public virtual DateTime ExpirationDate { get; protected set; }
        public virtual Boolean Active { get; protected set; }

        [ForeignKey("IdCategory")]
        public virtual Category Category { get; set; }

        [ForeignKey("IdType")]
        public virtual BusinessType Type { get; set; }

        [ForeignKey("IdLogo")]
        public virtual File Logo { get; set; }

        [ForeignKey("IdFather")]
        public virtual BusinessEntity BusinessEntityFather { get; set; }

        public virtual ICollection<BusinessEntity> ChildrenBusinessEntity { get; set; }

        public BusinessEntity(Guid id, Guid? idFather, Guid idType, Guid idCategory, string name, string description, Guid? idLogo, string contactName, string contactEmail, string contactPhone, string contactAddress, DateTime expirationDate, bool active) : this()
        {
            Id = id;
            IdFather = idFather;
            IdType = idType;
            IdCategory = idCategory;
            Name = name;
            Description = description;
            IdLogo = idLogo;
            ContactName = contactName;
            ContactEmail = contactEmail;
            ContactPhone = contactPhone;
            ContactAddress = contactAddress;
            ExpirationDate = expirationDate;
            Active = active;
        }

        public BusinessEntity(Guid? idFather, Guid idType, Guid idCategory, string name, string description, Guid? idLogo, string contactName, string contactEmail, string contactPhone, string contactAddress, DateTime expirationDate, bool active) : this()
        {
            IdFather = idFather;
            IdType = idType;
            IdCategory = idCategory;
            Name = name;
            Description = description;
            IdLogo = idLogo;
            ContactName = contactName;
            ContactEmail = contactEmail;
            ContactPhone = contactPhone;
            ContactAddress = contactAddress;
            ExpirationDate = expirationDate;
            Active = active;
        }

        public BusinessEntity()
        {
        }
    }
}
