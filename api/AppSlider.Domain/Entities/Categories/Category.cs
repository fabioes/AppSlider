using System;

namespace AppSlider.Domain.Entities.Categories
{
    public class Category : Entity<int>, IAggregateRoot
    {
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual bool Blocked { get; protected set; }

        public Category(int id, string name, string description, bool blocked) : this()
        {
            Id = id;
            Name = name;
            Description = description;
            Blocked = blocked;
        }

        public Category(string name, string description, bool blocked) : this()
        {
            Name = name;
            Description = description;
            Blocked = blocked;
        }

        public Category() { }
    }
}
