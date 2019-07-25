using System;

namespace AppSlider.Domain.Entities.Roles
{
    public class Role : Entity<Guid>, IAggregateRoot
    {
        public virtual String Name { get; protected set; }
        public virtual String Description { get; protected set; }
        
        public Role(String name, String description)
            : this()
        {
            Id = Guid.NewGuid();
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
