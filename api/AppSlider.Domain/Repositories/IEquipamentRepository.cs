namespace AppSlider.Domain.Repositories
{
    using AppSlider.Domain.Entities.Equipaments;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEquipamentRepository
    {
        Task<Equipament> Get(Guid id);
        Task<ICollection<Equipament>> GetAll();
        Task<Equipament> GetByMacAddress(string macAddress);
        Task<ICollection<Equipament>> GetByFranchise(Guid franshiseId);
        Task<Equipament> Add(Equipament equipament);
        Task<Equipament> Update(Equipament equipament);
        Task<Boolean> Delete(Equipament equipament);
        void DetachEquipament(Equipament equipament);
        Task<ICollection<Equipament>> GetSelectedByAdvertiser(Guid business);
    }
}
