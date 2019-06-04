using AppSlider.Application.TypeBusiness.Commands;
using AppSlider.Application.TypeBusiness.Results;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.TypeBusiness.Services.Create
{
    public class TypeBusinessCreateService : ITypeBusinessCreateService
    {
        private readonly IBusinessTypeRepository businessTypeRepository;
        
        public TypeBusinessCreateService(IBusinessTypeRepository businessTypeRepository)
        {
            this.businessTypeRepository = businessTypeRepository;
        }

        public async Task<TypeBusinessResult> Process(TypeBusinessCreateCommand command)
        {
            await TypeBusinessCreateValidationsAsync(command);

            var typeBusiness = new Domain.Entities.Business.BusinessType(command.Name, command.Description);

            await businessTypeRepository.Add(typeBusiness);

            var returnUser = (TypeBusinessResult)typeBusiness;

            return returnUser;
        }


        private async Task TypeBusinessCreateValidationsAsync(TypeBusinessCreateCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados do Tipo de Negócio!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.Name))
                    messageValidations.Add("Na criação de um Tipo de Negócio o 'Nome' é obrigatorio!");

                //Business Validations
                if ((await businessTypeRepository.GetByName(command.Name)) != null)
                {
                    messageValidations.Add("Tipo de Negócio já Existente!");
                }
            }
            
            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na criação do Tipo de Negócio {command?.Name ?? ""}", messageValidations, "TypeBusinessCreateService - Validations");
            }
        }
    }
}
