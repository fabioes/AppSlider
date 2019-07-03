using AppSlider.Application.Equipament.Commands;
using AppSlider.Application.Equipament.Results;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Equipament.Services.Create
{
    public class EquipamentCreateService : IEquipamentCreateService
    {
        private readonly IEquipamentRepository equipamentRepository;
        
        public EquipamentCreateService(IEquipamentRepository equipamentRepository)
        {
            this.equipamentRepository = equipamentRepository;
        }

        public async Task<EquipamentResult> Process(EquipamentCreateCommand command)
        {
            await EquipamentCreateValidationsAsync(command);

            var equipament = new Domain.Entities.Equipaments.Equipament(command.Name, command.Description, command.MacAddress, command.IdFranchise, command.IdEstablishment, command.IdPlaylist, command.Active);

            await equipamentRepository.Add(equipament);

            var returnEquipament = (EquipamentResult)equipament;

            return returnEquipament;
        }


        private async Task EquipamentCreateValidationsAsync(EquipamentCreateCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados do Equipamento!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.Name))
                    messageValidations.Add("Na criação de um Equipamento o 'Nome' é obrigatorio!");

                //Business Validations
                if ((await equipamentRepository.GetByMacAddress(command.MacAddress)) != null)
                {
                    messageValidations.Add("Equipamento já Existente!");
                }
            }
            
            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na criação do Equipamento {command?.Name ?? ""}", messageValidations, "EquipamentCreateService - Validations");
            }
        }
    }
}
