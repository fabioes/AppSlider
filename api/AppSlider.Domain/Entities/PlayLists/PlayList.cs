using AppSlider.Domain.Entities.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSlider.Domain.Entities.PlayLists
{
    public class Playlist : Entity<Guid>, IAggregateRoot
    {
        public virtual String Name { get; protected set; }
        public virtual Boolean Active { get; protected set; }
        public virtual Boolean Blocked { get; protected set; }
        public virtual DateTime Expirate { get; set; }
        public virtual Guid FranchiseId { get; set; }

        public virtual ICollection<PlaylistFile> PlaylistFiles { get; set; }

        [ForeignKey("FranchiseId")]
        public virtual BusinessEntity Franchise { get; set; }

        public Playlist(Guid id, string name, Boolean active, DateTime expirate, Guid franchiseId, Boolean blocked) : this()
        {
            Id = id;
            Name = name;
            Active = active;
            Expirate = expirate;
            FranchiseId = franchiseId;
            Blocked = blocked;
        }

        public Playlist(string name, Boolean active, DateTime expirate, Guid franchiseId, Boolean blocked) : this()
        {
            Name = name;
            Active = active;
            Expirate = expirate;
            FranchiseId = franchiseId;
            Blocked = blocked;
        }

        public Playlist()
        {
        }
    }

}
