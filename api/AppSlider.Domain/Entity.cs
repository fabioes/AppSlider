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
                if (!_id.HasValue)
                    _id = Guid.NewGuid();

                return _id.Value;
            }
            set
            {
                _id = value;
            }
        }
    }
}
