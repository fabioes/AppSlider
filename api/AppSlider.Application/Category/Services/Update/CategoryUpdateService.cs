using AppSlider.Application.Category.Commands;
using AppSlider.Application.Category.Results;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Category.Services.Update
{
    public class CategoryUpdateService : ICategoryUpdateService
    {
        private readonly ICategoryRepository categoryRepository;
        
        public CategoryUpdateService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<CategoryResult> Process(CategoryUpdateCommand command)
        {
            await CategoryUpdateValidationsAsync(command);

            var user = new Domain.Entities.Categories.Category(command.Id,  command.Name, command.Description);

            await categoryRepository.Update(user);

            var returnUser = (CategoryResult)user;

            return returnUser;
        }


        private async Task CategoryUpdateValidationsAsync(CategoryUpdateCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados da Categoria!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.Name))
                    messageValidations.Add("Na atualização de uma Categoria o 'Nome' é obrigatorio!");

                //Business Validations
                var catetoryValidation = await categoryRepository.GetByName(command.Name);

                if (catetoryValidation != null && catetoryValidation.Id != command.Id)
                {
                    messageValidations.Add("Categoria já existente!");
                }

                categoryRepository.DetachCategory(catetoryValidation);
            }
            
            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na atualização da categoria {command?.Name ?? ""}", messageValidations, "CategoryUpdateService - Validations");
            }
        }
    }
}
