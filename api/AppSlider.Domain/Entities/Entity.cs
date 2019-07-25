using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSlider.Domain.Entities
{
    public abstract class Entity<TId> 
    {
        public virtual TId Id { get; set; }
        //private TId _id { get; set; }

        //public virtual TId Id
        //{
        //    get
        //    {
        //        if (!_id.HasValue)
        //            _id = Guid.NewGuid();

        //        return _id.Value;
        //    }
        //    set
        //    {
        //        _id = value;
        //    }
        //}

        private DateTime? _dataCreated { get; set; }

        public virtual DateTime DataCreated
        {
            get
            {
                if (!_dataCreated.HasValue)
                    _dataCreated = DateTime.Now;

                return _dataCreated.Value;
            }
            set
            {
                _dataCreated = value;
            }
        }

        
    }
}
