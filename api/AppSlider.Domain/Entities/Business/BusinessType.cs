using System;

namespace AppSlider.Domain.Entities.Business
{
    public class BusinessType : Entity, IAggregateRoot
    {
        public virtual String Name { get; protected set; }
        public virtual String Description { get; protected set; }

        public BusinessType(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }

        public BusinessType(Guid id, string name, string description) : this()
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public BusinessType()
        {
        }
    }
}
