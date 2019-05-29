using AppSlider.Application.User.Commands;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.User.Services.Delete
{
    public class UserDeleteService : IUserDeleteService
    {
        private readonly IUserRepository userRepository;
        
        public UserDeleteService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;            
        }

        public async Task<Boolean> Process(UserDeleteCommand command)
        {
            UserDeleteValidations(command);

            var user = await userRepository.Get(command.Id.GetValueOrDefault());
            
            if (user == null)
                throw new BusinessException("Informe um Id de Usuário válido!");

            await userRepository.Delete(user);

            return true;
        }


        private void UserDeleteValidations(UserDeleteCommand command)
        {
            var messageValidations = new List<String>();

            if (command?.Id == null)
            {
                messageValidations.Add("Favor informar o Id Usuário que deseja excluir!");
            }
            
            if(messageValidations.Count > 0)
                throw new BusinessException($"Erro na deleção do usuário.", messageValidations, "UserDeleteService - Validations");
        }
    }
}
