﻿namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using AppSlider.Domain.Repositories;
    using AppSlider.Domain.Entities.Business;
    using System.Linq;

    public class BusinessRepository : IBusinessRepository
    {
        private readonly Context _context;

        public BusinessRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<BusinessEntity> Add(BusinessEntity businessEntity)
        {
            await _context.Business.AddAsync(businessEntity);
            await _context.SaveChangesAsync();

            return businessEntity;
        }

        public async Task<bool> Delete(BusinessEntity businessEntity)
        {
            _context.Business.Remove(businessEntity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<BusinessEntity> Get(Guid id)
        {
            var businessEntity = await _context.Business.FindAsync(id);

            return businessEntity;
        }

        public async Task<ICollection<BusinessEntity>> GetAll()
        {
            var businessEntities = await _context.Business.ToListAsync();

            return businessEntities;
        }


        public async Task<BusinessEntity> Update(BusinessEntity businessEntity)
        {
            _context.Business.Update(businessEntity);
            await _context.SaveChangesAsync();

            return businessEntity;
        }

        public void DetachBusiness(BusinessEntity businessEntity)
        {
            _context.Entry(businessEntity).State = EntityState.Detached;
        }

        public async Task<ICollection<BusinessEntity>> GetForLoggedUser(Domain.Entities.Users.User loggedUser)
        {

            var ids = loggedUser.Franchises?.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)?.Select(s => Guid.Parse(s))?.ToList();

            var businessEntities = await _context.Business.Include(i => i.Type).Where(w => w.Type.Name == "Franquia" && (loggedUser.Profile == "sa" || (ids != null && ids.Contains(w.Id)))).ToListAsync();

            return businessEntities;
        }
    }
}
