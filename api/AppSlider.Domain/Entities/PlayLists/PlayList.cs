using System;
using System.Collections.Generic;

namespace AppSlider.Domain.Entities.PlayLists
{
    public class PlayList : Entity, IAggregateRoot
    {
        public virtual String Name { get; protected set; }
        public virtual String Active { get; protected set; }
        public virtual DateTime Expirate { get; set; }

        public virtual ICollection<PlayListFile> PLayListFiles { get; set; }

        public PlayList(Guid id, string name, string active, DateTime expirate) : this()
        {
            Id = id;
            Name = name;
            Active = active;
            Expirate = expirate;
        }

        public PlayList(string name, string active, DateTime expirate) : this()
        {
            Name = name;
            Active = active;
            Expirate = expirate;
        }

        public PlayList()
        {
        }
    }

}
