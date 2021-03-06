namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using AppSlider.Domain.Repositories;
    using System.Linq;
    using AppSlider.Domain.Entities.Equipaments;
    using AppSlider.Infrastructure.DataAccess;

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
            var equipament = await _context.Equipaments.Include(i => i.Establishment).ThenInclude(x => x.Playlists).FirstOrDefaultAsync(f => f.MacAddress == macAddress && f.Active == true);

            return equipament;
        }

        public async Task<ICollection<Equipament>> GetAll()
        {
            var equipaments = await _context.Equipaments.OrderBy(x => x.Name).ToListAsync();

            return equipaments;
        }

        public async Task<ICollection<Equipament>> GetByFranchise(Guid franchiseId)
        {
            List<Equipament> equipaments = new List<Equipament>();
            var establishments = await _context.Business.Where(x => x.IdFather == franchiseId && x.IdType == 2).ToListAsync();


            foreach (var establishment in establishments)
            {
                var equipamentList = await _context.Equipaments.Where(w => w.IdEstablishment == establishment.Id).ToListAsync();
                equipaments.AddRange(equipamentList);
            }

            return equipaments;
        }
        public async Task<ICollection<Equipament>> GetByEstablishments(IList<Guid> establishmentIds)
        {
            List<Equipament> equipaments = new List<Equipament>();
            foreach (var item in establishmentIds)
            {
                var establishment = await _context.Business.FirstOrDefaultAsync(x => x.Id == item);
                var equipamentList = await _context.Equipaments.Where(w => w.IdEstablishment == establishment.Id).ToListAsync();
                equipaments.AddRange(equipamentList);
            }

            return equipaments;
        }
        public async Task<ICollection<Equipament>> GetSelectedByAdvertiser(Guid business)
        {
            var equipaments = from e in _context.Equipaments
                              join ae in _context.AdvertiserEquipament on e.Id equals ae.IdEquipament
                              where ae.IdAdvertiser == business
                              select e;

            return equipaments.ToList();
        }

        public async Task<Equipament> Update(Equipament equipament)
        {
            _context.DetachLocalIfExistsGuid(equipament);
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
