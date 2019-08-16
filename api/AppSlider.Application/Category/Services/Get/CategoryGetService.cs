using AppSlider.Application.Category.Results;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSlider.Application.Category.Services.Get
{
    public class CategoryGetService : ICategoryGetService
    {
        private readonly ICategoryRepository categoryRepository;
        
        public CategoryGetService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<CategoryResult> Get(int id)
        {
            var user = await categoryRepository.Get(id);

            var returnUser = (CategoryResult)user;

            return returnUser;
        }

        public async Task<CategoryResult> GetByName(String name)
        {
            var user = await categoryRepository.GetByName(name);

            var returnCategory = (CategoryResult)user;

            return returnCategory;
        }

        public async Task<List<CategoryResult>> GetAll()
        {
            var categories = await categoryRepository.GetAll();

            var returnCategories = categories.Select(s => (CategoryResult)s).ToList();
            
            return returnCategories;
        }
    }
}
