using AppSlider.Domain.Entities.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSlider.Domain.Entities.PlayLists
{
    public class Playlist : Entity<Guid>, IAggregateRoot
    {
        public virtual string Name { get; protected set; }
        public virtual bool Active { get; protected set; }
        public virtual bool Blocked { get; protected set; }
        public virtual DateTime Expirate { get; set; }
        public virtual Guid BusinessId { get; set; }

        public virtual ICollection<PlaylistFile> PlaylistFiles { get; set; }

        [ForeignKey("BusinessId")]
        public virtual BusinessEntity Franchise { get; set; }

        public Playlist(Guid id, string name, bool active, DateTime expirate, Guid busniessId, bool blocked) : this()
        {
            Id = id;
            Name = name;
            Active = active;
            Expirate = expirate;
            BusinessId = busniessId;
            Blocked = blocked;
        }

        public Playlist(string name, bool active, DateTime expirate, Guid franchiseId, bool blocked) : this()
        {
            Name = name;
            Active = active;
            Expirate = expirate;
            BusinessId = franchiseId;
            Blocked = blocked;
        }

        public Playlist()
        {
        }
    }

}
