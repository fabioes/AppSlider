﻿namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using AppSlider.Domain.Entities.Business;
    using Microsoft.EntityFrameworkCore;

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

            //modelBuilder.Seed();
        }
       
    }
}
