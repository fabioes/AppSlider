using AppSlider.Domain.Entities.Equipaments;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSlider.Domain.Entities.Business
{
    public class AdvertiserEquipament
    {
        public virtual Guid IdAdvertiser { get; set; }
        public virtual Advertiser Advertiser { get; set; }
        public virtual Guid IdEquipament { get; set; }

        public virtual Equipament Equipament { get; set; }
    }
}
