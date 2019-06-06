using System;

namespace AppSlider.Domain.Entities.Categories
{
    public class Category : Entity, IAggregateRoot
    {
        public virtual String Name { get; protected set; }
        public virtual String Description { get; protected set; }
        public virtual Boolean Blocked { get; protected set; }

        public Category(Guid id, string name, string description, Boolean blocked) : this()
        {
            Id = id;
            Name = name;
            Description = description;
            Blocked = blocked;
        }

        public Category(string name, string description, Boolean blocked) : this()
        {
            Name = name;
            Description = description;
            Blocked = blocked;
        }

        public Category() { }
    }
}
