using System;
using System.Collections.Generic;
using System.Text;

namespace AppSlider.Domain.Entities.Business
{
    public class Establishment : Entity<Guid>, IAggregateRoot
    {
        public virtual ICollection<AdvertiserEstablishments> AdvertisersEstablishments { get; set; }
        public Establishment(Guid id)
        {
            Id = id;

        }
    }
}
