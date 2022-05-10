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
        private readonly IBusinessRepository businessRepository;
        
        public EquipamentCreateService(IEquipamentRepository equipamentRepository,IBusinessRepository businessRepository)
        {
            this.equipamentRepository = equipamentRepository;
            this.businessRepository = businessRepository;
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

                //Business Validation
                var equipament = await equipamentRepository.GetByMacAddress(command.MacAddress);
                if ((equipament != null))
                {
                  
                    var franchise = await businessRepository.Get(equipament.IdFranchise);
                    messageValidations.Add($"Equipamento já Existente! Na Franquia {franchise.ContactCity}");
                }
            }
            
            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na criação do Equipamento {command?.Name ?? ""}", messageValidations, "EquipamentCreateService - Validations");
            }
        }
    }
}
