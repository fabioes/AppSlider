using System;

namespace AppSlider.Domain.Entities.Business
{
    public class BusinessType : Entity, IAggregateRoot
    {
        public virtual String Name { get; protected set; }
        public virtual String Description { get; protected set; }
        public virtual Boolean Blocked { get; protected set; }

        public BusinessType(Guid id, string name, string description, Boolean blocked) : this()
        {
            Id = id;
            Name = name;
            Description = description;
            Blocked = blocked;
        }

        public BusinessType(string name, string description, Boolean blocked) : this()
        {
            Name = name;
            Description = description;
            Blocked = blocked;
        }

        public BusinessType()
        {
        }
    }
}
