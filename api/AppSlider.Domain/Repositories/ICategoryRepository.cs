namespace AppSlider.Domain.Repositories
{
    using AppSlider.Domain.Entities.Categories;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryRepository
    {
        Task<Category> Get(Guid id);
        Task<ICollection<Category>> GetAll();
        Task<Category> GetByName(String name);
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<Boolean> Delete(Category category);
        void DetachCategory(Category category);
    }
}
