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
            List<BusinessEntity> children = null;
            UserUpdateValidations(command);
            if (command.Children != null)
            {
                children = Fill(command);
            }

            var business = new BusinessEntity(command.Id, command.IdFather, command.IdType, command.IdCategory, command.Name, command.CNPJ, command.Description, command.IdLogo, command.ContactName, command.ContactEmail, command.ContactPhone, command.ContactAddress, command.ContactCity, command.ExpirationDate, command.Active, false, command.File);
           // businessRepository.DetachBusiness(business);
            await businessRepository.Update(business);

            business.ChildrenBusinessEntity = children;

            if (command.IdType == 3)
                await businessRepository.UpdateAdvertiser(business);

            if (command.Equipaments != null && command.IdType == 3)
            {
                await businessRepository.RemoveAllAdvertiserEquipaments(business);
                foreach (var item in command.Equipaments)
                {
                    await businessRepository.UpdateEquipaments(new Domain.Entities.Business.AdvertiserEquipament()
                    {
                        IdAdvertiser = business.Id,
                        IdEquipament = item.Id
                    });
                }
            }

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
        private List<BusinessEntity> Fill(BusinessUpdateRequestCommand command)
        {
            List<BusinessEntity> businessEntities = new List<BusinessEntity>();

            foreach (var item in command.Children)
            {
                businessEntities.Add(new BusinessEntity(item.Id, item.IdFather, item.IdType, item.IdCategory
                    , item.Name, item.CNPJ, item.Description, item.IdLogo, item.ContactName,
                    item.ContactEmail, item.ContactPhone, item.ContactAddress, item.ContactCity, item.ExpirationDate, item.Active, false));
            }
            return businessEntities;
        }
    }
}
