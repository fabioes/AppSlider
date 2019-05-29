using AppSlider.Application.User.Commands;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Business.Services.Delete
{
    public class BusinessDeleteService : IBusinessDeleteService
    {
        private readonly IBusinessRepository businessRepository;
        
        public BusinessDeleteService(IBusinessRepository businessRepository)
        {
            this.businessRepository = businessRepository;            
        }

        public async Task<Boolean> Process(Guid? id)
        {
            UserDeleteValidations(id);

            var business = await businessRepository.Get(id.GetValueOrDefault());
            
            if (business == null)
                throw new BusinessException("Informe um Id de Negócio válido!");

            await businessRepository.Delete(business);

            return true;
        }


        private void UserDeleteValidations(Guid? id)
        {
            var messageValidations = new List<String>();

            if (id == null)
            {
                messageValidations.Add("Favor informar o Id do Negócio que deseja excluir!");
            }
            
            if(messageValidations.Count > 0)
                throw new BusinessException($"Erro na deleção do Negócio.", messageValidations, "BusinessDeleteService - Validations");
        }
    }
}
