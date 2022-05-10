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
        public virtual String Name { get; protected set; }
        public virtual long? CNPJ { get; protected set; }
        public virtual String Description { get; protected set; }
        public virtual Guid? IdLogo { get; protected set; }
        public virtual String ContactName { get; protected set; }
        public virtual String ContactEmail { get; protected set; }
        public virtual String ContactPhone { get; protected set; }
        public virtual String ContactAddress { get; protected set; }
        public virtual String ContactCity { get; protected set; }
        public virtual DateTime? ExpirationDate { get; protected set; }
        public virtual Boolean Active { get; set; }
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

        public virtual IList<Playlist> Playlists { get; set; }

        public BusinessEntity(Guid id, Guid? idFather, int idType, int? idCategory, string name, long? CNPJ, string description, Guid? idLogo, string contactName, string contactEmail, string contactPhone, string contactAddress, string contactCity, DateTime? expirationDate, bool active, bool blocked, byte[] file = null, List<BusinessEntity> children = null) : this()
        {
            Id = id;
            IdFather = idFather;
            IdType = idType;
            IdCategory = idCategory;
            Name = name;
            this.CNPJ = CNPJ;
            Description = description;
            IdLogo = idLogo;
            ContactName = contactName;
            ContactEmail = contactEmail;
            ContactPhone = contactPhone;
            ContactAddress = contactAddress;
            ContactCity = contactCity;
            ExpirationDate = expirationDate;
            Active = active;
            Blocked = blocked;
            File = file;
            ChildrenBusinessEntity = children;
        }

        public BusinessEntity(Guid? idFather, int idType, int? idCategory, string name, long? CNPJ, string description, Guid? idLogo, string contactName, string contactEmail, string contactPhone, string contactAddress, string contactCity, DateTime? expirationDate, bool active, bool blocked, byte[] file = null, List<BusinessEntity> children = null) : this()
        {
            IdFather = idFather;
            IdType = idType;
            IdCategory = idCategory;
            Name = name;
            this.CNPJ = CNPJ;
            Description = description;
            IdLogo = idLogo;
            ContactName = contactName;
            ContactEmail = contactEmail;
            ContactPhone = contactPhone;
            ContactAddress = contactAddress;
            ContactCity = contactCity;
            ExpirationDate = expirationDate;
            Active = active;
            Blocked = blocked;
            File = file;
            ChildrenBusinessEntity = children;

        }

        public BusinessEntity()
        {
        }
    }
}
