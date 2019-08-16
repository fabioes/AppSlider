using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Category.Services.Delete
{
    public class CategoryDeleteService : ICategoryDeleteService
    {
        private readonly ICategoryRepository categoryRepository;
        
        public CategoryDeleteService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;            
        }

        public async Task<Boolean> Process(int id)
        {
            CategoryDeleteValidations(id);

            var user = await categoryRepository.Get(id);
            
            if (user == null)
                throw new BusinessException("Informe um Id da Categoria válida!");

            await categoryRepository.Delete(user);

            return true;
        }


        private void CategoryDeleteValidations(int id)
        {
            var messageValidations = new List<String>();

            if (id == 0)
            {
                messageValidations.Add("Favor informar o Id da Categoria que deseja excluir!");
            }
            
            if(messageValidations.Count > 0)
                throw new BusinessException($"Erro na deleção da categoria.", messageValidations, "CategoryDeleteService - Validations");
        }
    }
}
