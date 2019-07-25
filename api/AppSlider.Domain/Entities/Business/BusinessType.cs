namespace AppSlider.Domain.Entities.Business
{
    public class BusinessType : Entity<int>, IAggregateRoot
    {
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual bool Blocked { get; protected set; }

        public BusinessType(int id, string name, string description, bool blocked) : this()
        {
            Id = id;
            Name = name;
            Description = description;
            Blocked = blocked;
        }

        public BusinessType(string name, string description, bool blocked) : this()
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
