using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Equipament.Services.Delete
{
    public class EquipamentDeleteService : IEquipamentDeleteService
    {
        private readonly IEquipamentRepository equipamentRepository;
        
        public EquipamentDeleteService(IEquipamentRepository equipamentRepository)
        {
            this.equipamentRepository = equipamentRepository;            
        }

        public async Task<Boolean> Process(Guid id)
        {
            EquipamentDeleteValidations(id);

            var equipament = await equipamentRepository.Get(id);
            
            if (equipament == null)
                throw new BusinessException("Informe um Id de Equipamento válido!");

            await equipamentRepository.Delete(equipament);

            return true;
        }


        private void EquipamentDeleteValidations(Guid id)
        {
            var messageValidations = new List<String>();

            if (id == new Guid())
            {
                messageValidations.Add("Favor informar o Id do Equipamento que deseja excluir!");
            }
            
            if(messageValidations.Count > 0)
                throw new BusinessException($"Erro na deleção do Equipamento.", messageValidations, "EquipamentDeleteService - Validations");
        }
    }
}
