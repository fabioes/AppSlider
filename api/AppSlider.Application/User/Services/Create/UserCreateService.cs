using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Results;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSlider.Application.User.Services.Create
{
    public class UserCreateService : IUserCreateService
    {
        private readonly IUserRepository userRepository;
        
        public UserCreateService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserResult> Process(UserCreateCommand command)
        {
            await UserCreateValidationsAsync(command);

            var user = new Domain.Entities.Users.User(command.Name,
                command.UserName,
                command.Password,
                command.Profile,
                command.Email,
                command.Franchises != null ? String.Join(",", command.Franchises) : null,
                command.Roles != null ? String.Join(",", command.Roles) : null,
                command.Active);

            await userRepository.Add(user);

            var returnUser = (UserResult)user;

            return returnUser;
        }


        private async Task UserCreateValidationsAsync(UserCreateCommand command)
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
                if ((await userRepository.GetByUsername(command.UserName)) != null)
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
