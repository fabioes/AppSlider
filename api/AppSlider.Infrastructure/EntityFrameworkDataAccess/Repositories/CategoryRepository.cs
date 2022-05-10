namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using AppSlider.Domain.Entities.Categories;
    using AppSlider.Domain.Repositories;
    using System.Linq;
    using AppSlider.Infrastructure.DataAccess;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Category> Add(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<bool> Delete(Category category)
        {
            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Category> Get(int id)
        {
            var user = await _context.Categories.FindAsync(id);

            return user;
        }

        public async Task<ICollection<Category>> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> GetByName(string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(f => f.Name == name);
            return category;
        }

        public async Task<Category> Update(Category category)
        {
          
                var local = _context.Set<Category>().Local.FirstOrDefault(e => e.Id == category.Id);

                if (local == null) local = category;

                _context.Entry(local).State = local == null ? EntityState.Modified : EntityState.Detached;
      
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public void DetachCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Detached;
        }
    }
}
