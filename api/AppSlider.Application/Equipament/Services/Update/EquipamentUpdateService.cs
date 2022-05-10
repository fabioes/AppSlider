using AppSlider.Application.Equipament.Commands;
using AppSlider.Application.Equipament.Results;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Equipament.Services.Update
{
    public class EquipamentUpdateService : IEquipamentUpdateService
    {
        private readonly IEquipamentRepository equipamentRepository;
        
        public EquipamentUpdateService(IEquipamentRepository equipamentRepository)
        {
            this.equipamentRepository = equipamentRepository;
        }

        public async Task<EquipamentResult> Process(EquipamentUpdateCommand command)
        {
            await TypeBusinessUpdateValidationsAsync(command);

            var equipament = new Domain.Entities.Equipaments.Equipament(command.Id, command.Name, command.Description, command.MacAddress, command.IdFranchise, command.IdEstablishment, command.IdPlaylist, command.Active);

            await equipamentRepository.Update(equipament);

            var returnEquipament = (EquipamentResult)equipament;

            return returnEquipament;
        }


        private async Task TypeBusinessUpdateValidationsAsync(EquipamentUpdateCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados do Equipamento!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.Name))
                    messageValidations.Add("Na atualização de um Equipamento o 'Nome' é obrigatório!");

                //Business Validations
                var equipamentValidation = await equipamentRepository.GetByMacAddress(command.MacAddress);

                if (equipamentValidation != null && equipamentValidation.Id != command.Id)
                {
                    messageValidations.Add("Equipamento já existente!");
                }              
            }
            
            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na atualização do Equipamento {command?.Name ?? ""}", messageValidations, "EquipamentUpdateService - Validations");
            }
        }
    }
}
