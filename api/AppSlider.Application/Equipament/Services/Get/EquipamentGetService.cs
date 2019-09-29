using AppSlider.Application.Equipament.Results;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSlider.Application.Equipament.Services.Get
{
    public class EquipamentGetService : IEquipamentGetService
    {
        private readonly IEquipamentRepository equipamentRepository;
        
        public EquipamentGetService(IEquipamentRepository equipamentRepository)
        {
            this.equipamentRepository = equipamentRepository;
        }

        public async Task<EquipamentResult> Get(Guid id)
        {
            var equipament = await equipamentRepository.Get(id);

            var returnEquipament = (EquipamentResult)equipament;

            return returnEquipament;
        }

        public async Task<EquipamentResult> GetByMacAddress(String macAddress)
        {
            var equipament = await equipamentRepository.GetByMacAddress(macAddress);

            var returnEquipament = (EquipamentResult)equipament;

            return returnEquipament;
        }

        public async Task<List<EquipamentResult>> GetByFranchise(Guid franchiseId)
        {
            var equipaments = await equipamentRepository.GetByFranchise(franchiseId);

            var returnEquipaments = equipaments?.Select(s => (EquipamentResult)s).ToList();

            return returnEquipaments;
        }
        public async Task<List<EquipamentResult>> GetByEstablishments(IList<Guid> establishemntIds)
        {
            var equipaments = await equipamentRepository.GetByEstablishments(establishemntIds);

            var returnEquipaments = equipaments?.Select(s => (EquipamentResult)s).ToList();

            return returnEquipaments;
        }


        public async Task<List<EquipamentResult>> GetAll()
        {
            var equipaments = await equipamentRepository.GetAll();

            var returnEquipaments = equipaments?.Select(s => (EquipamentResult)s).ToList();
            
            return returnEquipaments;
        }
        public async Task<List<EquipamentResult>> GetSelectedByAdvertiser(Guid businessId)
        {
            var equipaments = await equipamentRepository.GetSelectedByAdvertiser(businessId);
            var returnEquipaments = equipaments?.Select(s => (EquipamentResult)s).ToList();

            return returnEquipaments;
        }
    }
}
