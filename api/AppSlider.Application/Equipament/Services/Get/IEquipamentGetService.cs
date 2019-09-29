using AppSlider.Application.Equipament.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Equipament.Services.Get
{
    public interface IEquipamentGetService
    {
        Task<EquipamentResult> Get(Guid id);

        Task<List<EquipamentResult>> GetByFranchise(Guid franchiseId);
        Task<List<EquipamentResult>> GetByEstablishments(IList<Guid> establishmentIds);

        Task<EquipamentResult> GetByMacAddress(String macAddress);

        Task<List<EquipamentResult>> GetAll();
        Task<List<EquipamentResult>> GetSelectedByAdvertiser(Guid businessId);
    }
}
