using AppSlider.Application.Category.Commands;
using AppSlider.Application.Category.Results;
using AppSlider.Domain;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Category.Services.Create
{
    public class CategoryCreateService : ICategoryCreateService
    {
        private readonly ICategoryRepository categoryRepository;
        
        public CategoryCreateService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<CategoryResult> Process(CategoryCreateCommand command)
        {
            await CategoryCreateValidationsAsync(command);

            var category = new Domain.Entities.Categories.Category(command.Name, command.Description, false);

            await categoryRepository.Add(category);

            var returnUser = (CategoryResult)category;

            return returnUser;
        }


        private async Task CategoryCreateValidationsAsync(CategoryCreateCommand command)
        {
            var messageValidations = new List<String>();

            if (command == null)
            {
                messageValidations.Add("Favor informar os dados da Categoria!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(command.Name))
                    messageValidations.Add("Na criação de uma Categoria o 'Nome' é obrigatorio!");

                //Business Validations
                if ((await categoryRepository.GetByName(command.Name)) != null)
                {
                    messageValidations.Add("Categoria já Existente!");
                }
            }
            
            if (messageValidations.Count > 0)
            {
                throw new BusinessException($"Erro na criação da Categoria {command?.Name ?? ""}", messageValidations, "CategoryCreateService - Validations");
            }
        }
    }
}
