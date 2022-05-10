using AppSlider.Application.Business.Commands;
using AppSlider.Application.Business.Results;
using AppSlider.Domain;
using AppSlider.Domain.Entities.Business;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Business.Services.Create
{
    public class BusinessCreateService : IBusinessCreateService
    {
        private readonly IBusinessRepository businessRepository;

        public BusinessCreateService(IBusinessRepository businessRepository)
        {
            this.businessRepository = businessRepository;
        }

        public async Task<BusinessResult> Process(BusinessCreateRequestCommand command)
        {
            UserCreateValidations(command);
            List<BusinessEntity> children = null;
            var business = new BusinessEntity(command.IdFather, command.IdType, command.IdCategory, command.Name, command.CNPJ, command.Description, command.IdLogo, command.ContactName, command.ContactEmail, command.ContactPhone, command.ContactAddress, command.ContactCity,command.ExpirationDate, command.Active, false, command.File) ;
            if(command.IdType == 3)
            {
                business.Id = Guid.NewGuid();
                if (command.Children != null)
                {
                    children = Fill(command);
                }
                business.ChildrenBusinessEntity = children;
                await businessRepository.InsertAdvertiserBusiness(business);
                foreach (var item in command.Equipaments)
                {
                    try
                    {
                        await businessRepository.UpdateEquipaments(new AdvertiserEquipament()
                        {
                            IdAdvertiser = business.Id,
                            IdEquipament = (Guid)item.Id
                        });
                    }
                    catch (Exception)
                    {


                    }

                }
            }
            else
            {
                await businessRepository.Add(business);

            }

            var returnBusiness = (BusinessResult)business;

            return returnBusiness;
        }


        private void UserCreateValidations(BusinessCreateRequestCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados do Negócio!");
            }
            else
            {
                //if (String.IsNullOrWhiteSpace(command.UserName))
                //    messageValidations.Add("Na criação de um Usuário o 'Login' é obrigatorio!");

                //if (String.IsNullOrWhiteSpace(command.Password))
                //    messageValidations.Add("Na criação de um Usuário a 'Senha' é obrigatoria!");

                ////Business Validations
                //if ((await businessRepository.GetByUsername(command.UserName)) != null)
                //{
                //    messageValidations.Add("Login já Existente!");
                //}
            }

            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na criação do Negócio {command?.Name ?? ""}", messageValidations, "BusinessCreateService - Validations");
            }
        }
        private List<BusinessEntity> Fill(BusinessCreateRequestCommand command)
        {
            List<BusinessEntity> businessEntities = new List<BusinessEntity>();

            foreach (var item in command.Children)
            {
                businessEntities.Add(new BusinessEntity((Guid)item.Id, item.IdFather, item.IdType, item.IdCategory
                    , item.Name, item.CNPJ, item.Description, item.IdLogo, item.ContactName,
                    item.ContactEmail, item.ContactPhone, item.ContactAddress, item.ContactCity, item.ExpirationDate, item.Active, false));
            }
            return businessEntities;
        }
    }
}
