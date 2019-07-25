namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using AppSlider.Domain.Repositories;
    using AppSlider.Domain.Entities.Business;

    public class BusinessTypeRepository : IBusinessTypeRepository
    {
        private readonly Context _context;

        public BusinessTypeRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<BusinessType> Add(BusinessType businessType)
        {
            await _context.BusinessTypes.AddAsync(businessType);
            await _context.SaveChangesAsync();

            return businessType;
        }

        public async Task<bool> Delete(BusinessType businessType)
        {
            _context.BusinessTypes.Remove(businessType);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<BusinessType> Get(Guid id)
        {
            var businessType = await _context.BusinessTypes.FindAsync(id);

            return businessType;
        }

        public async Task<ICollection<BusinessType>> GetAll()
        {
            var businessTypes = await _context.BusinessTypes.ToListAsync();

            return businessTypes;
        }

        public async Task<BusinessType> GetByName(string name)
        {
            var businessType = await _context.BusinessTypes.FirstOrDefaultAsync(f => f.Name == name);
            return businessType;
        }

        public async Task<BusinessType> Update(BusinessType businessType)
        {
            //_context.DetachLocalIfExists(businessType);

            _context.BusinessTypes.Update(businessType);
            await _context.SaveChangesAsync();

            return businessType;
        }

        public void DetachBusinessType(BusinessType businessType)
        {
            _context.Entry(businessType).State = EntityState.Detached;
        }
    }
}
