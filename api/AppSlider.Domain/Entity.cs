using System;

namespace AppSlider.Domain
{
    public class Entity : IEntity
    {
        private Guid? _id { get; set; }

        public virtual Guid Id
        {
            get
            {
                return _id ?? Guid.NewGuid();
            }
            set
            {
                _id = value;
            }
        }
    }
}
