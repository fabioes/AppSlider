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
            if (type != "Franquia")
            {
                return businessEntities.OrderBy(x => x.LegalName).ToList();
            }
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
                    var equi = await _context.AdvertiserEquipament.Where(x => x.IdAdvertiser == item.Id).ToListAsync();
                    foreach (var estab in ad)
                    {
                        childBusiness = await _context.Business.FirstOrDefaultAsync(x => x.Id == estab.IdEstablishment);

                        item?.ChildrenBusinessEntity?.Add(childBusiness);
                    }

                }

            }
            if (type != "Franquia")
            {
                return businessEntities.OrderBy(x => x.LegalName).ToList();
            }
            else
            {
                return businessEntities.OrderBy(x => x.ContactCity).ToList();
            }

        }

        public async Task UpdateEquipaments(AdvertiserEquipament advertiserEquipament)
        {

            var local = _context.Set<AdvertiserEquipament>().Local.FirstOrDefault(e => e.IdAdvertiser == advertiserEquipament.IdAdvertiser);

            if (local == null) local = advertiserEquipament;

            _context.Entry(local).State = local == null ? EntityState.Modified : EntityState.Detached;


            _context.AdvertiserEquipament.Add(advertiserEquipament);
            await _context.SaveChangesAsync();

        }

        public async Task<BusinessEntity> Update(BusinessEntity businessEntity)
        {
            //_context.DetachLocalIfExistsGuid(businessEntity);

            var business = _context.Business.FirstOrDefault(x => x.Id == businessEntity.Id);

            if (business != null)
            {
                _context.Entry(business).CurrentValues.SetValues(businessEntity);
                await _context.SaveChangesAsync();
            }

            return businessEntity;
        }
        public async Task<List<BusinessEntity>> GetAdvertisers(Guid id)
        {
            List<BusinessEntity> businessEntities = new List<BusinessEntity>();
            var advertisers = await _context.AdvertiserEquipament.Where(x => x.IdEquipament == id).ToListAsync();
            foreach (var advertiser in advertisers)
            {
                businessEntities.Add(await Get(advertiser.IdAdvertiser));
            }

            return businessEntities;
        }

        public void DetachBusiness(BusinessEntity businessEntity)
        {
            _context.Entry(businessEntity).State = EntityState.Detached;
        }

        public async Task<ICollection<BusinessEntity>> GetForLoggedUser(LoggedUser loggedUser)
        {
            var ids = loggedUser.Franchises?.Select(s => Guid.Parse(s))?.ToList();

            var businessEntities = await _context.Business.Include(i => i.Type).Where(w => w.Type.Name == "Franquia" && (loggedUser.Profile == "sa" || (ids != null && ids.Contains(w.Id)))).OrderBy(x => x.ContactCity).ToListAsync();

            return businessEntities;
        }
        public async Task<BusinessEntity> UpdateAdvertiser(BusinessEntity businessEntity)
        {
            _context.Entry(businessEntity).State = EntityState.Detached;
            var advertiserEstablishment = await _context.AdvertiserEstablishments.Where(x => x.IdAdvertiser == businessEntity.Id).ToListAsync();
            if (advertiserEstablishment.Count > 0)
            {
                _context.AdvertiserEstablishments.RemoveRange(advertiserEstablishment);
                await _context.SaveChangesAsync();

                if (businessEntity.ChildrenBusinessEntity != null)
                    foreach (var children in businessEntity.ChildrenBusinessEntity)
                    {
                        _context.AdvertiserEstablishments.Add(new AdvertiserEstablishments { IdAdvertiser = businessEntity.Id, IdEstablishment = children.Id });
                    }
            }
            else
            {
                if (businessEntity.ChildrenBusinessEntity != null)   {  
                    var advertiser =  _context.Advertisers.FirstOrDefault(x => x.Id == businessEntity.Id);   
                         
                     if(advertiser == null){
                    _context.Advertisers.Add(new Advertiser (businessEntity.Id)); 
                    await _context.SaveChangesAsync();   
                     }                    
                       
                    foreach (var children in businessEntity.ChildrenBusinessEntity)
                    {
                       var establishment = _context.Establishments.FirstOrDefault(x => x.Id == children.Id);   
                       if(establishment == null)
                         _context.Establishments.Add(new Establishment (children.Id));
                        
                        _context.AdvertiserEstablishments.Add(new AdvertiserEstablishments { IdAdvertiser = businessEntity.Id, IdEstablishment = children.Id });
                    }
                }
            }
            await _context.SaveChangesAsync();
            return businessEntity;

        }

        public async Task RemoveAllAdvertiserEquipaments(BusinessEntity businessEntity)
        {
            var advertiserEquipament = new AdvertiserEquipament() { IdAdvertiser = businessEntity.Id };


            if (_context.AdvertiserEquipament.Any(x => x.IdAdvertiser == businessEntity.Id))
            {
                var li = _context.AdvertiserEquipament.Where(x => x.IdAdvertiser == businessEntity.Id).ToList();
                _context.AdvertiserEquipament.RemoveRange(li);

                await _context.SaveChangesAsync();
            }
        }
    }
}
