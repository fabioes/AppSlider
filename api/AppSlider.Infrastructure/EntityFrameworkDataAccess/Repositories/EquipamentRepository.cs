namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using AppSlider.Domain.Repositories;
    using System.Linq;
    using AppSlider.Domain.Entities.Equipaments;

    public class EquipamentRepository : IEquipamentRepository
    {
        private readonly Context _context;

        public EquipamentRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Equipament> Add(Equipament equipament)
        {
            await _context.Equipaments.AddAsync(equipament);
            await _context.SaveChangesAsync();

            return equipament;
        }

        public async Task<bool> Delete(Equipament equipament)
        {
            _context.Equipaments.Remove(equipament);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Equipament> Get(Guid id)
        {
            var equipament = await _context.Equipaments.FindAsync(id);

            return equipament;
        }

        public async Task<Equipament> GetByMacAddress(string macAddress)
        {
            var equipament = await _context.Equipaments.FirstOrDefaultAsync(f => f.MacAddress == macAddress);

            return equipament;
        }

        public async Task<ICollection<Equipament>> GetAll()
        {
            var equipaments = await _context.Equipaments.ToListAsync();

            return equipaments;
        }

        public async Task<ICollection<Equipament>> GetByFranchise(Guid franchiseId)
        {
            var equipaments = await _context.Equipaments.Where(w => w.IdFranchise == franchiseId).ToListAsync();
            return equipaments;
        }

        public async Task<Equipament> Update(Equipament equipament)
        {
            _context.Equipaments.Update(equipament);
            await _context.SaveChangesAsync();

            return equipament;
        }

        public void DetachEquipament(Equipament equipament)
        {
            _context.Entry(equipament).State = EntityState.Detached;
        }
    }
}
