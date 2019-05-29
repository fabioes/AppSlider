using AppSlider.Domain.Entities.Business;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Domain.Repositories
{
    public interface IBusinessRepository
    {
        Task<BusinessEntity> Get(Guid id);
        Task<ICollection<BusinessEntity>> GetAll();
        Task<BusinessEntity> Add(BusinessEntity businessEntity);
        Task<BusinessEntity> Update(BusinessEntity businessEntity);
        Task<Boolean> Delete(BusinessEntity businessEntity);
        void DetachBusiness(BusinessEntity businessEntity);
    }
}
