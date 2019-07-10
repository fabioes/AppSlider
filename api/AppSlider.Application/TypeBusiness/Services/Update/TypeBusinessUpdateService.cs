using AppSlider.Application.TypeBusiness.Commands;
using AppSlider.Application.TypeBusiness.Results;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.TypeBusiness.Services.Update
{
    public class TypeBusinessUpdateService : ITypeBusinessUpdateService
    {
        private readonly IBusinessTypeRepository businessTypeRepository;

        public TypeBusinessUpdateService(IBusinessTypeRepository businessTypeRepository)
        {
            this.businessTypeRepository = businessTypeRepository;
        }

        public async Task<TypeBusinessResult> Process(TypeBusinessUpdateCommand command)
        {
            await TypeBusinessUpdateValidationsAsync(command);

            var businessType = new Domain.Entities.Business.BusinessType(command.Id, command.Name, command.Description, false);

            await businessTypeRepository.Update(businessType);

            var returnBusinessType = (TypeBusinessResult)businessType;

            return returnBusinessType;
        }


        private async Task TypeBusinessUpdateValidationsAsync(TypeBusinessUpdateCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados do Tipo de Negócio!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.Name))
                    messageValidations.Add("Na atualização de um Tipo de Negócio o 'Nome' é obrigatório!");

                //Business Validations
                var businessTypeValidation = await businessTypeRepository.GetByName(command.Name);

                if (businessTypeValidation != null)
                {


                    if (businessTypeValidation.Id != command.Id)
                    {
                        messageValidations.Add("Tipo de Negócio já existente!");
                    }

                    businessTypeRepository.DetachBusinessType(businessTypeValidation);
                }

            }

            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na atualização do Tipo de Negócio {command?.Name ?? ""}", messageValidations, "TypeBusinessUpdateService - Validations");
            }
        }
    }
}
