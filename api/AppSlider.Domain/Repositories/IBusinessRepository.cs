using AppSlider.Domain.Authentication;
using AppSlider.Domain.Entities.Business;
using AppSlider.Domain.Entities.Equipaments;
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
        Task<ICollection<BusinessEntity>> GetByFranchiseAndType(Guid franchiseId, String type);
        Task<ICollection<BusinessEntity>> GetByFranchiseAndType(Guid franchiseId, String type, int page);
        Task<List<BusinessEntity>> GetAdvertisers(Guid id);
        Task<BusinessEntity> Add(BusinessEntity businessEntity);
        Task<BusinessEntity> Update(BusinessEntity businessEntity);
        Task<Boolean> Delete(BusinessEntity businessEntity);
        void DetachBusiness(BusinessEntity businessEntity);
        Task<ICollection<BusinessEntity>> GetForLoggedUser(LoggedUser loggedUser);
        Task<BusinessEntity> UpdateAdvertiser(BusinessEntity businessEntity);
        Task<BusinessEntity> InsertAdvertiserBusiness(BusinessEntity businessEntity);
        Task<BusinessEntity> UpdateAdvertiserBusiness(BusinessEntity businessEntity);
        Task<BusinessEntity> UpdateAdvertiserActive(BusinessEntity businessEntity);
        Task UpdateEquipaments(AdvertiserEquipament advertiserEquipament);
        Task RemoveAllAdvertiserEquipaments(BusinessEntity businessEntity);
        Task<int> CountItems(Guid franchiseId, String type);
    }
}
