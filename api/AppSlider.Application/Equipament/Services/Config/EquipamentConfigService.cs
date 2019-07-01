using AppSlider.Application.Equipament.Results;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AppSlider.Application.Equipament.Services.Config
{
    public class EquipamentConfigService : IEquipamentConfigService
    {
        private readonly IEquipamentRepository equipamentRepository;

        public EquipamentConfigService(IEquipamentRepository equipamentRepository)
        {
            this.equipamentRepository = equipamentRepository;
        }

        public async Task<EquipamentResult> SwitchActive(Guid id)
        {
            EquipamentConfigSwitchActiveValidations(id);

            var equipament = await equipamentRepository.Get(id);

            if (equipament == null)
                throw new BusinessException($"Erro na ativação / desativação do Equipamento", new List<string> { "Negócio Inexistente!" }, "EquipamentConfigService - Validations");

            var domainEquipament = new Domain.Entities.Equipaments.Equipament(equipament.Id, equipament.Name, equipament.Description, equipament.MacAddress, equipament.IdFranchise, equipament.IdEstablishment, equipament.IdPlaylist, !equipament.Active);

            equipamentRepository.DetachEquipament(equipament);

            await equipamentRepository.Update(domainEquipament);

            var returnEquipament = (EquipamentResult)domainEquipament;

            return returnEquipament;
        }

        private void EquipamentConfigSwitchActiveValidations(Guid id)
        {
            var messageValidations = new List<String>();

            if (id == new Guid())
            {
                messageValidations.Add("Para ativar / desativar um Equipamento o 'Id' é obrigatorio!");
            }

            if (messageValidations.Count > 0)
            {
                throw new BusinessException("Erro na atualização do Equipamento", messageValidations, "EquipamentConfigService - Validations");
            }
        }
    }
}
