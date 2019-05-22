using System;

namespace AppSlider.Domain.Contracts
{
    public class Contract : Entity, IAggregateRoot
    {
        public virtual String Name { get; protected set; }
        public virtual String Description { get; protected set; }

        public Contract(String name, String description)
            : this()
        {
            Name = name;
            Description = description;
        }

        public Contract(Guid id, String name, String description)
            : this()
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Contract()
        {
        }
    }
}
