using AppSlider.Domain.Entities.Business;
using AppSlider.Domain.Entities.PlayLists;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppSlider.Domain.Entities.Equipaments
{
    public class Equipament : Entity, IAggregateRoot
    {
        
        public String Name { get; set; }

        public String Description { get; set; }

        public String MacAddress { get; set; }

        public Guid IdFranchise { get; set; }

        public Guid? IdEstablishment { get; set; }

        public Guid? IdPlaylist { get; set; }

        public Boolean Active { get; set; }


        [ForeignKey("IdFranchise")]
        public BusinessEntity Franchise { get; set; }

        [ForeignKey("IdEstablishment")]
        public BusinessEntity Establishment { get; set; }

        [ForeignKey("IdPlaylist")]
        public Playlist PlayList { get; set; }


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
