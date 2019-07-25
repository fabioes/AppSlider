using AppSlider.Domain.Entities.Business;
using AppSlider.Domain.Entities.PlayLists;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSlider.Domain.Entities.BusinessPlayLists
{
    public class BusinessPlayList : Entity<Guid>, IAggregateRoot
    {
        public virtual Guid IdBusiness { get; protected set; }
        public virtual Guid IdPlayList { get; protected set; }

        [ForeignKey("IdPlayList")]
        public virtual Playlist PlayList { get; protected set; }

        [ForeignKey("IdBusiness")]
        public virtual BusinessEntity Business { get; protected set; }

        public BusinessPlayList(Guid id, Guid idBusiness, Guid idPlayList) : this()
        {
            Id = id;
            IdBusiness = idBusiness;
            IdPlayList = idPlayList;
        }

        public BusinessPlayList(Guid idBusiness, Guid idPlayList) : this()
        {
            IdBusiness = idBusiness;
            IdPlayList = idPlayList;
        }

        public BusinessPlayList() { }
    }
}
