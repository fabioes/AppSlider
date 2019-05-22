using AppSlider.Application.Login.Messages;
using AppSlider.Application.User.Results;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Login.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository userRepository;
        
        public LoginService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserResult> Process(LoginRequest command)
        {
            UserLoginValidations(command);

            var user = await userRepository.GetByUsername(command.Username);

            if (user == null)
            {
                throw new BusinessException("Usuario Inválido!", "LoginService", false);
            }

            if (user.Password != command.Password)
            {
                throw new BusinessException("Senha Inválida!", "LoginService", false);
            }

            var returnUser = (UserResult)user;

            return returnUser;
        }

        private void UserLoginValidations(LoginRequest command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados do Acesso!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.Username))
                    messageValidations.Add("O 'Login' é obrigatorio!");

                if (String.IsNullOrWhiteSpace(command.Password))
                    messageValidations.Add("A 'Senha' é obrigatoria!");
            }

            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro ao validar o Login {command?.Username ?? ""}", messageValidations, "LoginService - Validations");
            }
        }
    }
}
