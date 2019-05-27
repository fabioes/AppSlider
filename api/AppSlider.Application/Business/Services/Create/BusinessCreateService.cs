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

        public async Task<BusinessResult> Process(BusinessCreateCommand command)
        {
            await UserCreateValidationsAsync(command);

            var user = new BusinessEntity(command.IdFather, command.UserName, command.Password, command.Profile, command.Email, command.Franchises, command.Roles, command.Active);

            await businessRepository.Add(user);

            var returnUser = (UserResult)user;

            return returnUser;
        }


        private async Task UserCreateValidationsAsync(BusinessCreateCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados do Usuário!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.UserName))
                    messageValidations.Add("Na criação de um Usuário o 'Login' é obrigatorio!");

                if (String.IsNullOrWhiteSpace(command.Password))
                    messageValidations.Add("Na criação de um Usuário a 'Senha' é obrigatoria!");

                //Business Validations
                if ((await businessRepository.GetByUsername(command.UserName)) != null)
                {
                    messageValidations.Add("Login já Existente!");
                }
            }
            
            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na criação do usuário {command?.UserName ?? ""}", messageValidations, "UserCreateService - Validations");
            }
        }
    }
}
