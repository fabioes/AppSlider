using AppSlider.Domain.Entities.Business;
using AppSlider.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Domain.Repositories
{
    public interface IBusinessRepository
    {
        Task<BusinessEntity> Get(Guid id);
        Task<ICollection<BusinessEntity>> GetAll();
        Task<ICollection<BusinessEntity>> GetByType(String type);
        Task<BusinessEntity> Add(BusinessEntity businessEntity);
        Task<BusinessEntity> Update(BusinessEntity businessEntity);
        Task<Boolean> Delete(BusinessEntity businessEntity);
        void DetachBusiness(BusinessEntity businessEntity);
        Task<ICollection<BusinessEntity>> GetForLoggedUser(User loggedUser);
    }
}
