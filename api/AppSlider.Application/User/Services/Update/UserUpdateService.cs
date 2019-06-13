using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Results;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.User.Services.Update
{
    public class UserUpdateService : IUserUpdateService
    {
        private readonly IUserRepository userRepository;
        
        public UserUpdateService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserResult> Process(UserUpdateCommand command)
        {
            await UserUpdateValidationsAsync(command);

            var user = new Domain.Entities.Users.User(command.Id,
                command.Name,
                command.UserName,
                command.Profile,
                command.Email,
                command.Franchises != null ? String.Join(",", command.Franchises) : null,
                command.Roles != null ? String.Join(",", command.Roles) : null,
                command.Active);

            await userRepository.Update(user);

            var returnUser = (UserResult)user;

            return returnUser;
        }


        private async Task UserUpdateValidationsAsync(UserUpdateCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados do Usuário!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.UserName))
                    messageValidations.Add("Na atualização de um Usuário o 'Login' é obrigatorio!");

                //Business Validations
                var userValidation = await userRepository.GetByUsername(command.UserName);

                if (userValidation != null && userValidation.Id != command.Id)
                {
                    messageValidations.Add("Login já existente!");
                }
            }
            
            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na atualização do usuário {command?.UserName ?? ""}", messageValidations, "UserUpdateService - Validations");
            }
        }
    }
}
