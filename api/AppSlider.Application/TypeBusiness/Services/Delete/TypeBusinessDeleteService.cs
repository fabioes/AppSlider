using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.TypeBusiness.Services.Delete
{
    public class TypeBusinessDeleteService : ITypeBusinessDeleteService
    {
        private readonly IBusinessTypeRepository businessTypeRepository;
        
        public TypeBusinessDeleteService(IBusinessTypeRepository businessTypeRepository)
        {
            this.businessTypeRepository = businessTypeRepository;            
        }

        public async Task<Boolean> Process(Guid id)
        {
            TypeBusinessDeleteValidations(id);

            var businessType = await businessTypeRepository.Get(id);
            
            if (businessType == null)
                throw new BusinessException("Informe um Id de Tipo de Negócio válida!");

            await businessTypeRepository.Delete(businessType);

            return true;
        }


        private void TypeBusinessDeleteValidations(Guid id)
        {
            var messageValidations = new List<String>();

            if (id == new Guid())
            {
                messageValidations.Add("Favor informar o Id do Tipo de Negócio que deseja excluir!");
            }
            
            if(messageValidations.Count > 0)
                throw new BusinessException($"Erro na deleção do Tipo de Negócio.", messageValidations, "TypeBusinessDeleteService - Validations");
        }
    }
}
