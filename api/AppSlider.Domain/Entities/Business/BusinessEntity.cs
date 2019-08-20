using AppSlider.Domain.Entities.Categories;
using AppSlider.Domain.Entities.Files;
using AppSlider.Domain.Entities.PlayLists;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSlider.Domain.Entities.Business
{
    public class BusinessEntity : Entity<Guid>, IAggregateRoot
    {
        public virtual Guid? IdFather { get; set; } = Guid.NewGuid();
        public virtual int IdType { get; set; }
        public virtual int? IdCategory { get; set; }
        public virtual String LegalName { get; protected set; }
        public virtual long? CNPJ { get; protected set; }
        public virtual String Description { get; protected set; }
        public virtual Guid? IdLogo { get; protected set; }
        public virtual String ContactName { get; protected set; }
        public virtual String ContactEmail { get; protected set; }
        public virtual String ContactPhone { get; protected set; }
        public virtual String ContactAddress { get; protected set; }
        public virtual DateTime? ExpirationDate { get; protected set; }
        public virtual Boolean Active { get; protected set; }
        public virtual Boolean Blocked { get; protected set; }

        public virtual byte[] File { get; set; }

        [ForeignKey("IdCategory")]
        public virtual Category Category { get; set; }

        [ForeignKey("IdType")]
        public virtual BusinessType Type { get; set; }

        [ForeignKey("IdLogo")]
        public virtual File Logo { get; set; }

        [ForeignKey("IdFather")]
        public virtual BusinessEntity BusinessEntityFather { get; set; }

        public virtual ICollection<BusinessEntity> ChildrenBusinessEntity { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }

        public BusinessEntity(Guid id, Guid? idFather, int idType, int? idCategory, string name, long? CNPJ, string description, Guid? idLogo, string contactName, string contactEmail, string contactPhone, string contactAddress, DateTime? expirationDate, bool active, bool blocked, byte[] file = null) : this()
        {
            Id = id;
            IdFather = idFather;
            IdType = idType;
            IdCategory = idCategory;
            LegalName = name;
            this.CNPJ = CNPJ;
            Description = description;
            IdLogo = idLogo;
            ContactName = contactName;
            ContactEmail = contactEmail;
            ContactPhone = contactPhone;
            ContactAddress = contactAddress;
            ExpirationDate = expirationDate;
            Active = active;
            Blocked = blocked;
            File = file;
        }

        public BusinessEntity(Guid? idFather, int idType, int? idCategory, string name, long? CNPJ, string description, Guid? idLogo, string contactName, string contactEmail, string contactPhone, string contactAddress, DateTime? expirationDate, bool active, bool blocked, byte[] file = null) : this()
        {
            IdFather = idFather;
            IdType = idType;
            IdCategory = idCategory;
            LegalName = name;
            this.CNPJ = CNPJ;
            Description = description;
            IdLogo = idLogo;
            ContactName = contactName;
            ContactEmail = contactEmail;
            ContactPhone = contactPhone;
            ContactAddress = contactAddress;
            ExpirationDate = expirationDate;
            Active = active;
            Blocked = blocked;
            File = file;
        }

        public BusinessEntity()
        {
        }
    }
}
