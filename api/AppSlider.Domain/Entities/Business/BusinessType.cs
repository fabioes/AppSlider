using System;

namespace AppSlider.Domain.Entities.Business
{
    public class BusinessType : Entity, IAggregateRoot
    {
        public virtual String Name { get; protected set; }
        public virtual String Description { get; protected set; }

        public BusinessType(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
