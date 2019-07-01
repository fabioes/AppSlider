using AppSlider.Domain.Entities.Business;
using AppSlider.Domain.Entities.Categories;
using AppSlider.Domain.Entities.Equipaments;
using AppSlider.Domain.Entities.Files;
using AppSlider.Domain.Entities.PlayLists;
using AppSlider.Domain.Entities.Roles;
using AppSlider.Domain.Entities.Users;
using AppSlider.Utils.Cripto;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.Active).HasColumnType("bit");
            modelBuilder.Entity<User>().Property(p => p.Blocked).HasColumnType("bit");

            modelBuilder.Entity<BusinessEntity>().Property(p => p.Active).HasColumnType("bit");
            modelBuilder.Entity<BusinessEntity>().Property(p => p.Blocked).HasColumnType("bit");

            modelBuilder.Entity<BusinessType>().Property(p => p.Blocked).HasColumnType("bit");
            modelBuilder.Entity<BusinessType>().HasIndex(p => p.Name);

            modelBuilder.Entity<Category>().Property(p => p.Blocked).HasColumnType("bit");

            modelBuilder.Entity<Equipament>().Property(p => p.Active).HasColumnType("bit");

            //Strings Lenght's
            modelBuilder.Entity<User>().Property(p => p.Name).HasMaxLength(200);
            modelBuilder.Entity<User>().Property(p => p.Username).HasMaxLength(50);

            modelBuilder.Entity<Role>().Property(p => p.Name).HasMaxLength(200);
            modelBuilder.Entity<Role>().Property(p => p.Description).HasMaxLength(500);

            modelBuilder.Entity<BusinessEntity>().Property(p => p.Name).HasMaxLength(200);
            modelBuilder.Entity<BusinessEntity>().Property(p => p.Description).HasMaxLength(500);
            modelBuilder.Entity<BusinessEntity>().Property(p => p.ContactName).HasMaxLength(200);
            modelBuilder.Entity<BusinessEntity>().Property(p => p.ContactEmail).HasMaxLength(200);
            modelBuilder.Entity<BusinessEntity>().Property(p => p.ContactPhone).HasMaxLength(50);
            modelBuilder.Entity<BusinessEntity>().Property(p => p.ContactAddress).HasMaxLength(300);

            modelBuilder.Entity<BusinessType>().Property(p => p.Name).HasMaxLength(200);
            modelBuilder.Entity<BusinessType>().Property(p => p.Description).HasMaxLength(500);

            modelBuilder.Entity<Category>().Property(p => p.Name).HasMaxLength(200);
            modelBuilder.Entity<Category>().Property(p => p.Description).HasMaxLength(500);
            
            modelBuilder.Entity<Equipament>().Property(p => p.Name).HasMaxLength(200);
            modelBuilder.Entity<Equipament>().Property(p => p.Description).HasMaxLength(500);
            modelBuilder.Entity<Equipament>().Property(p => p.MacAddress).HasMaxLength(200);

            //Index.
            modelBuilder.Entity<Equipament>().HasIndex(p => p.MacAddress);

            //Has data ---> Seed Fact.
            modelBuilder.Entity<User>().HasData(
                new User("Administrador", "admin", CriptoManager.CriptoSHA256("AdminAppSlider@123"), "sa", "", null, null, true, true)
            );

            modelBuilder.Entity<Role>().HasData(
                new Role("AppSlider.Read.User", "Permissão de leitura para rotina de Usuário."),
                new Role("AppSlider.Write.User", "Permissão de escrita para rotina de Usuário."),
                new Role("AppSlider.Read.Business", "Permissão de leitura para rotina de Negócio."),
                new Role("AppSlider.Write.Business", "Permissão de escrita para rotina de Negócio."),
                new Role("AppSlider.Read.BusinessType", "Permissão de leitura para rotina de Tipos de Negócio."),
                new Role("AppSlider.Write.BusinessType", "Permissão de escrita para rotina de Tipos de Negócio."),
                new Role("AppSlider.Read.Category", "Permissão de leitura para rotina de Categoria."),
                new Role("AppSlider.Write.Category", "Permissão de escrita para rotina de Categoria."),
                new Role("AppSlider.Read.Playlist", "Permissão de leitura para rotina de Playlist."),
                new Role("AppSlider.Write.Playlist", "Permissão de escrita para rotina de Playlist."),
                new Role("AppSlider.Read.Equipament", "Permissão de leitura para rotina de Equipamento."),
                new Role("AppSlider.Write.Equipament", "Permissão de escrita para rotina de Equipamento.")
            );

        var midiaFoneFranchiseCategory = new Category("MidiaFone", "Categoria MidiaFone.", true);

            modelBuilder.Entity<Category>().HasData(
                midiaFoneFranchiseCategory
            );

            var midiaFoneFranchiseType = new BusinessType("Franquia", "Franquia como Tipo de Negócio.", true);

            modelBuilder.Entity<BusinessType>().HasData(
                midiaFoneFranchiseType,
                new BusinessType("Estabelecimento", "Estabelecimento como Tipo de Negócio.", true),
                new BusinessType("Anunciante", "Anunciante como Tipo de Negócio.", true)
            );

            var midiaFoneFranchise = new BusinessEntity(null, midiaFoneFranchiseType.Id, midiaFoneFranchiseCategory.Id, "MidiaFone", "Franquia padrão 'MidiaFone'", null, "", "", "", "", null, true, true);

            modelBuilder.Entity<BusinessEntity>().HasData(
                midiaFoneFranchise
            );
            
            modelBuilder.Entity<PlayList>().HasData(
                new PlayList("Curiosidades MidiaFone", true, DateTime.MaxValue, midiaFoneFranchise.Id, true));
        }
    }
}
