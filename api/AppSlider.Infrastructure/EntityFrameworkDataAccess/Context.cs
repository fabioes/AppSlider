namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using AppSlider.Domain.Entities;
    using AppSlider.Domain.Entities.Business;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Domain.Entities.Users.User> Users { get; set; }
        public DbSet<Domain.Entities.Roles.Role> Roles { get; set; }
        public DbSet<Domain.Entities.Categories.Category> Categories { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<Domain.Entities.Files.File> Files { get; set; }
        public DbSet<BusinessEntity> Business { get; set; }
        public DbSet<Domain.Entities.PlayLists.Playlist> PlayLists { get; set; }
        public DbSet<Domain.Entities.PlayLists.PlaylistFile> PlayListFiles { get; set; }
        public DbSet<Domain.Entities.BusinessPlayLists.BusinessPlayList> BusinessPlayLists { get; set; }
        public DbSet<Domain.Entities.Equipaments.Equipament> Equipaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Users.User>()
                .ToTable("Users");

            modelBuilder.Entity<Domain.Entities.Roles.Role>()
                .ToTable("Roles");

            modelBuilder.Entity<Domain.Entities.Categories.Category>()
                .ToTable("Categories");

            modelBuilder.Entity<Domain.Entities.Business.BusinessType>()
                .ToTable("BusinessTypes");

            modelBuilder.Entity<Domain.Entities.Files.File>()
               .ToTable("Files");

            modelBuilder.Entity<BusinessEntity>()
                
                .ToTable("Business")                
                .HasMany(m => m.ChildrenBusinessEntity)
                .WithOne(o => o.BusinessEntityFather)
                .HasForeignKey(fk => fk.IdFather);

            modelBuilder.Entity<Domain.Entities.PlayLists.Playlist>()
               .ToTable("Playlists");

            modelBuilder.Entity<Domain.Entities.PlayLists.PlaylistFile>()
               .ToTable("PlaylistFiles");

            modelBuilder.Entity<Domain.Entities.BusinessPlayLists.BusinessPlayList>()
               .ToTable("BusinessPlaylists");

            modelBuilder.Entity<Domain.Entities.Equipaments.Equipament>()
               .ToTable("Equipaments");

            modelBuilder.Seed();
        }
        //public bool Exists<T>(T entity) where T : Domain.Entities.Entity 
        //{
        //    return this.Set<T>().Local.Any(e => e.Id == entity.Id);
        //}


        public void DetachLocalIfExists<T>(T entity) where T : Entity<int>
        {
            var local = this.Set<T>().Local.FirstOrDefault(e => e.Id == entity.Id);

            if (local == null) local = entity;

            this.Entry(local).State = local == null ? EntityState.Modified : EntityState.Detached;
        }
        public void DetachLocalIfExistsGuid<T>(T entity) where T : Entity<Guid>
        {
            var local = this.Set<T>().Local.FirstOrDefault(e => e.Id == entity.Id);

            if (local == null) local = entity;

            this.Entry(local).State = local == null ? EntityState.Modified : EntityState.Detached;
        }

    }
}
