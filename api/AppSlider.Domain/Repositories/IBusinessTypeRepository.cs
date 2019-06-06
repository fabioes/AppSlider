namespace AppSlider.Domain.Repositories
{
    using AppSlider.Domain.Entities.Business;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBusinessTypeRepository
    {
        Task<BusinessType> Get(Guid id);
        Task<ICollection<BusinessType>> GetAll();
        Task<BusinessType> GetByName(String name);
        Task<BusinessType> Add(BusinessType businessType);
        Task<BusinessType> Update(BusinessType businessType);
        Task<Boolean> Delete(BusinessType businessType);
        void DetachBusinessType(BusinessType businessType);
    }
}
