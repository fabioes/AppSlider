using System;

namespace AppSlider.Domain.Roles
{
    public class Role : Entity, IAggregateRoot
    {
        public virtual String Name { get; protected set; }
        public virtual String Description { get; protected set; }
        
        public Role(String name, String description)
            : this()
        {
            Name = name;
            Description = description;
        }

        public Role(Guid id, String name, String description)
            : this()
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Role()
        {
        }
    }
}
