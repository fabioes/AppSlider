using System;

namespace AppSlider.Application.Equipament.Commands
{
    public class EquipamentCreateCommand
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public String Description { get; set; }

        public String MacAddress { get; set; }

        public Guid IdFranchise { get; set; }

        public Guid? IdEstablishment { get; set; }

        public Guid? IdPlaylist { get; set; }

        public Boolean Active { get; set; }

        public EquipamentCreateCommand(Guid id,string name, string description, string macAddress, Guid idFranchise, Guid? idEstablishment, Guid? idPlaylist, bool active)
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
        public EquipamentCreateCommand(string name, string description, string macAddress, Guid idFranchise, Guid? idEstablishment, Guid? idPlaylist, bool active)
        {
            
            Name = name;
            Description = description;
            MacAddress = macAddress;
            IdFranchise = idFranchise;
            IdEstablishment = idEstablishment;
            IdPlaylist = idPlaylist;
            Active = active;
        }
    }
}
