using AppSlider.Domain.Entities.Equipaments;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSlider.Domain.Entities.Business
{
    public class Advertiser : Entity<Guid>, IAggregateRoot
    {
        public virtual ICollection<AdvertiserEstablishments> AdvertisersEstablishments { get; set; }
        public virtual ICollection<AdvertiserEquipament> AdvertisersEquipament { get; set; }
        public Advertiser(Guid id)
        {
            Id = id;
            AdvertisersEquipament = new List<AdvertiserEquipament>();
        }
    }
}
