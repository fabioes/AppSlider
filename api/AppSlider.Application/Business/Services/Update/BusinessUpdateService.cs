using AppSlider.Application.Business.Commands;
using AppSlider.Application.Business.Results;
using AppSlider.Domain;
using AppSlider.Domain.Entities.Business;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Business.Services.Update
{
    public class BusinessUpdateService : IBusinessUpdateService
    {
        private readonly IBusinessRepository businessRepository;
        
        public BusinessUpdateService(IBusinessRepository businessRepository)
        {
            this.businessRepository = businessRepository;
        }

        public async Task<BusinessResult> Process(BusinessUpdateRequestCommand command)
        {
            UserUpdateValidations(command);

            var business = new BusinessEntity(command.IdFather, command.IdType, command.IdCategory, command.Name, command.Description, command.IdLogo, command.ContactName, command.ContactEmail, command.ContactPhone, command.ContactAddress, command.ExpirationDate, command.Active);

            await businessRepository.Update(business);

            var returnUser = (BusinessResult)business;

            return returnUser;
        }


        private void UserUpdateValidations(BusinessUpdateRequestCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados do Negócio!");
            }
            else
            {
                //if (String.IsNullOrWhiteSpace(command.UserName))
                //    messageValidations.Add("Na atualização de um Negócio o 'Login' é obrigatorio!");                                
            }

            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na atualização do Negócio {command?.Name ?? ""}", messageValidations, "BusinessUpdateService - Validations");
            }
        }
    }
}
