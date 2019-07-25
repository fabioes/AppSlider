using AppSlider.Domain.Entities.Business;
using AppSlider.Domain.Entities.PlayLists;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppSlider.Domain.Entities.Equipaments
{
    public class Equipament : Entity<Guid>, IAggregateRoot
    {
        
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual string MacAddress { get; set; }

        public virtual Guid IdFranchise { get; set; }

        public virtual Guid? IdEstablishment { get; set; }

        public virtual Guid? IdPlaylist { get; set; }

        public virtual bool Active { get; set; }


        [ForeignKey("IdFranchise")]
        public virtual BusinessEntity Franchise { get; set; }

        [ForeignKey("IdEstablishment")]
        public virtual BusinessEntity Establishment { get; set; }

        [ForeignKey("IdPlaylist")]
        public virtual Playlist PlayList { get; set; }


        public Equipament(Guid id, string name, string description, string macAddress, Guid idFranchise, Guid? idEstablishment, Guid? idPlaylist, bool active) : this()
        {
            Id = id;
            Name = name;
            Description = description;
            MacAddress = macAddress;
            IdFranchise = idFranchise;
            IdEstablishment = idEstablishment;
            IdPlaylist = idPlaylist;
            Active = active;
        }

        public Equipament(string name, string description, string macAddress, Guid idFranchise, Guid? idEstablishment, Guid? idPlaylist, bool active): this()
        {
            Name = name;
            Description = description;
            MacAddress = macAddress;
            IdFranchise = idFranchise;
            IdEstablishment = idEstablishment;
            IdPlaylist = idPlaylist;
            Active = active;
        }

        public Equipament()
        {
        }
    }
}
