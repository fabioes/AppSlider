using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppSlider.Domain.Entities.Business
{
    public class AdvertiserEstablishments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual Guid IdAdvertiser { get; set; }
        public virtual Advertiser Advertiser { get; set; }
        public virtual Guid IdEstablishment { get; set; }

        public virtual Establishment Establishment { get; set; }
    }
}
