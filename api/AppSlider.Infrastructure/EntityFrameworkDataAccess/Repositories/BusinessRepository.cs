namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using AppSlider.Domain.Repositories;
    using AppSlider.Domain.Entities.Business;
    using System.Linq;
    using AppSlider.Domain.Authentication;
    using AppSlider.Domain.Entities.Equipaments;

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

        public async Task<ICollection<BusinessEntity>> GetByType(String type)
        {
            var businessEntities = await _context.Business.Include(i => i.Type).Where(w => w.Type.Name == type).ToListAsync();

            return businessEntities;
        }

        public async Task<ICollection<BusinessEntity>> GetByFranchiseAndType(Guid franchiseId, String type)
        {
            var businessEntities = await _context.Business.Include(i => i.Type).Where(w => w.IdFather == franchiseId && w.Type.Name == type).ToListAsync();
            if (type == "Anunciante")
            {
                BusinessEntity childBusiness = new BusinessEntity();

                foreach (var item in businessEntities)
                {
                    item.ChildrenBusinessEntity = new List<BusinessEntity>();
                    var ad = await _context.AdvertiserEstablishments.Where(x => x.IdAdvertiser == item.Id).ToListAsync();
                    foreach (var estab in ad)
                    {
                        childBusiness = await _context.Business.FirstOrDefaultAsync(x => x.Id == estab.IdEstablishment);

                        item?.ChildrenBusinessEntity?.Add(childBusiness);
                    }
                }


            }
            return businessEntities;
        }

        public async Task UpdateEquipaments(Equipament equipament)
        {
            //var entity = _context.Equipaments.FirstOrDefault(x => x.Id == equipament.Id);
            //entity.Advertiser = equipament.Advertiser;

            //_context.DetachLocalIfExistsGuid(entity);
            //_context.Equipaments.Update(entity);
            //await _context.SaveChangesAsync();

        }

        public async Task<BusinessEntity> Update(BusinessEntity businessEntity)
        {
            _context.DetachLocalIfExistsGuid(businessEntity);

            await _context.SaveChangesAsync();

            return businessEntity;
        }

        public void DetachBusiness(BusinessEntity businessEntity)
        {
            _context.Entry(businessEntity).State = EntityState.Detached;
        }

        public async Task<ICollection<BusinessEntity>> GetForLoggedUser(LoggedUser loggedUser)
        {
            var ids = loggedUser.Franchises?.Select(s => Guid.Parse(s))?.ToList();

            var businessEntities = await _context.Business.Include(i => i.Type).Where(w => w.Type.Name == "Franquia" && (loggedUser.Profile == "sa" || (ids != null && ids.Contains(w.Id)))).ToListAsync();

            return businessEntities;
        }
        public async Task<BusinessEntity> UpdateAdvertiser(BusinessEntity businessEntity)
        {
            DetachBusiness(businessEntity);
            var advertiser = new Advertiser(businessEntity.Id);
            if (!_context.Advertisers.Any(x => x.Id == businessEntity.Id))
                _context.Advertisers.Add(advertiser);
            if (businessEntity.ChildrenBusinessEntity != null)
                foreach (var children in businessEntity.ChildrenBusinessEntity)
                {
                    var establishment = new Establishment(children.Id);
                    if (!_context.Establishments.Any(x => x.Id == children.Id))
                        _context.Establishments.Add(establishment);
                    var advertiserstablishment = new AdvertiserEstablishments() { Advertiser = advertiser, Establishment = establishment };

                    _context.AdvertiserEstablishments.Add(advertiserstablishment);
                    _context.Entry(advertiserstablishment).State = advertiserstablishment == null ? EntityState.Modified : EntityState.Detached;
                    _context.Entry(advertiser).State = advertiser == null ? EntityState.Modified : EntityState.Detached;
                    _context.Entry(establishment).State = establishment == null ? EntityState.Modified : EntityState.Detached;
                }
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                throw ex;
            }


            return businessEntity;
        }
    }
}
