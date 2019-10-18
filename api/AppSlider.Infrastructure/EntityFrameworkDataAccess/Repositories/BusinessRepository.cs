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
    using Dapper;

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
            var businessEntity = await _context.Business.FirstOrDefaultAsync(x => x.Id == id);

            return businessEntity;
        }
        private async Task<BusinessEntity> GetActive(Guid id)
        {
            var businessEntity = await _context.Business.FirstOrDefaultAsync(x => x.Id == id && x.Active == true && x.ExpirationDate > DateTime.Now);

            return businessEntity;
        }

        public async Task<ICollection<BusinessEntity>> GetAll()
        {
            RefreshAll();
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
        public void RefreshAll()
        {
            foreach (var entity in _context.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }

        public async Task<ICollection<BusinessEntity>> GetByFranchiseAndType(Guid franchiseId, String type)
        {
            RefreshAll();
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
            var db = _context.Database.GetDbConnection();
            await db.ExecuteAsync("INSERT INTO AdvertiserEquipament (IdAdvertiser,IdEquipament) VALUES (@IdAdvertiser,@IdEquipament)", new { IdAdvertiser = advertiserEquipament.IdAdvertiser, IdEquipament = advertiserEquipament.IdEquipament });

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
        public async Task<BusinessEntity> UpdateAdvertiserBusiness(BusinessEntity businessEntity)
        {
            var db = _context.Database.GetDbConnection();
            if (db.State != System.Data.ConnectionState.Open)
                db.Open();
            var result = await db.ExecuteAsync("UPDATE Business SET `Active` = @Active , " +
               "ExpirationDate = @ExpirationDate WHERE Id = @Id ", new { businessEntity.Active, businessEntity.ExpirationDate, businessEntity.Id, });

            return businessEntity;
        }
        public async Task<BusinessEntity> UpdateAdvertiserActive(BusinessEntity businessEntity)
        {
            var db = _context.Database.GetDbConnection();
            if (db.State != System.Data.ConnectionState.Open)
                db.Open();
            var result = await db.ExecuteAsync("UPDATE Business SET `Active` = @Active  WHERE Id = @Id ", new { businessEntity.Active, businessEntity.Id, });

            return businessEntity;
        }
        public async Task<List<BusinessEntity>> GetAdvertisers(Guid id)
        {
            List<BusinessEntity> businessEntities = new List<BusinessEntity>();
            var advertisers = await _context.AdvertiserEquipament.Where(x => x.IdEquipament == id).ToListAsync();
            foreach (var advertiser in advertisers)
            {
                var idAdvertiser = await GetActive(advertiser.IdAdvertiser);
                if (idAdvertiser != null)
                {
                    businessEntities.Add(idAdvertiser);
                }
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
            var db = _context.Database.GetDbConnection();

            var advertiserEstablishment = await _context.AdvertiserEstablishments.Where(x => x.IdAdvertiser == businessEntity.Id).ToListAsync();
            if (advertiserEstablishment.Count > 0)
            {
                await db.ExecuteAsync("DELETE FROM AdvertiserEstablishments WHERE IdAdvertiser = @Id", new { businessEntity.Id });


                if (businessEntity.ChildrenBusinessEntity != null)
                    foreach (var children in businessEntity.ChildrenBusinessEntity)
                    {
                        if(children.Id != null)
                            try
                            {
                                await db.ExecuteAsync("INSERT INTO AdvertiserEstablishments (IdAdvertiser,IdEstablishment) VALUES (@IdAdvertiser,@IdEstablishment)", new { IdAdvertiser = businessEntity.Id, IdEstablishment = children.Id });
                            }
                            catch (Exception)
                            {
                               
                            }                        
                    }
            }
            else
            {
                if (businessEntity.ChildrenBusinessEntity != null)
                {
                    var advertiser = _context.Advertisers.FirstOrDefault(x => x.Id == businessEntity.Id);

                    if (advertiser == null)
                    {
                        await db.ExecuteAsync("INSERT INTO Advertisers (Id,DataCreated) VALUES (@IdAdvertiser,NOW())", new { IdAdvertiser = businessEntity.Id });
                    }

                    foreach (var children in businessEntity.ChildrenBusinessEntity)
                    {
                        var establishment = _context.Establishments.FirstOrDefault(x => x.Id == children.Id);
                        if (establishment == null)
                            await db.ExecuteAsync("INSERT INTO Establishments (Id,DataCreated) VALUES (@IdEstablishment,NOW())", new { IdEstablishment = children.Id });

                        await db.ExecuteAsync("INSERT INTO AdvertiserEstablishments (IdAdvertiser,IdEstablishment) VALUES (@IdAdvertiser,@IdEstablishment)", new { IdAdvertiser = businessEntity.Id, IdEstablishment = children.Id });
                    }
                }
            }

            return businessEntity;

        }

        public async Task RemoveAllAdvertiserEquipaments(BusinessEntity businessEntity)
        {
            var db = _context.Database.GetDbConnection();
            await db.ExecuteAsync("DELETE FROM AdvertiserEquipament WHERE IdAdvertiser = @Id", new { businessEntity.Id });
        }
    }
}
