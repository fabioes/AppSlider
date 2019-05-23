using AppSlider.Application.User.Commands;
using AppSlider.Application.User.Results;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AppSlider.Application.User.Services.Config
{
    public class UserConfigService : IUserConfigService
    {
        private readonly IUserRepository userRepository;
        
        public UserConfigService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserResult> SwitchActive(UserConfigCommand command)
        {
            UserConfigSwitchActiveValidations(command);
            
            var user = await userRepository.Get(command.Id);

            if(user == null)
                throw new BusinessException($"Erro na ativação / desativação do usuário", new List<string> {"Usuário Inexistente!"}, "UserConfigService - Validations");

            var domainUser = new Domain.Users.User(user.Id, user.Name, user.Username, user.Password, user.Profile, user.Email, !user.Active);

            userRepository.DetachUser(user);

            await userRepository.Update(domainUser);

            var returnUser = (UserResult)domainUser;

            return returnUser;
        }

        public async Task<UserResult> ResetPassword(UserConfigCommand command)
        {
            UserConfigResetPasswordValidations(command);

            var user = await userRepository.Get(command.Id);

            if (user == null)
                throw new BusinessException($"Erro na redefinição de senha do usuário", new List<string> { "Usuário Inexistente!" }, "UserConfigService - Validations");

            userRepository.DetachUser(user);

            var updatedUser = await userRepository.Update(new Domain.Users.User(user.Id, user.Name, user.Username, command.Password, user.Profile, user.Email, !user.Active));

            var returnUser = (UserResult)updatedUser;

            return returnUser;
        }


        private void UserConfigSwitchActiveValidations(UserConfigCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados do Usuário!");
            }
            else
            {
                if (command.Id == new Guid())
                    messageValidations.Add("Para ativar / desativar um Usuário o 'Id' é obrigatorio!");
            }
            
            if (messageValidations.Count > 0)
            {
                throw new BusinessException("Erro na atualização do usuário", messageValidations, "UserConfigService - Validations");
            }
        }

        private void UserConfigResetPasswordValidations(UserConfigCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados do Usuário!");
            }
            else
            {
                if (command.Id == new Guid())
                    messageValidations.Add("Para redefinição de senha de um Usuário o 'Id' é obrigatorio!");

                if (String.IsNullOrWhiteSpace(command.Password))
                    messageValidations.Add("Para redefinição de senha de um Usuário a 'Senha' é obrigatoria!");
            }

            if (messageValidations.Count > 0)
            {
                throw new BusinessException("Erro na atualização do usuário", messageValidations, "UserConfigService - Validations");
            }
        }
    }
}
