using AppSlider.Domain.Entities.Business;
using AppSlider.Domain.Entities.Categories;
using AppSlider.Domain.Entities.Roles;
using AppSlider.Domain.Entities.Users;
using AppSlider.Utils.Cripto;
using Microsoft.EntityFrameworkCore;

namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User("Administrador", "admin", CriptoManager.CriptoSHA256("AdminAppSlider@123"), "admin", "", null, null, true)
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
                new Role("AppSlider.Write.Playlist", "Permissão de escrita para rotina de Playlist.")
            );

            var midiaFoneFranchiseCategory = new Category("MidiaFone", "Categoria MidiaFone.", true);

            modelBuilder.Entity<Category>().HasData(
                midiaFoneFranchiseCategory
            );

            var midiaFoneFranchiseType = new BusinessType("Franquia", "Franquia como Tipo de Negócio.", true);

            modelBuilder.Entity<BusinessType>().HasData(
                midiaFoneFranchiseType,
                new BusinessType("Estabelecimento", "Estabelecimento como Tipo de Negócio.", true),
                new BusinessType("Anunciante", "Anunciente como Tipo de Negócio.", true)
            );

            modelBuilder.Entity<BusinessEntity>().HasData(
                new BusinessEntity(null, midiaFoneFranchiseType.Id, midiaFoneFranchiseCategory.Id, "MidiaFone", "Franquia padrão 'MidiaFone'", null, "", "", "", "", null, true)
            );
        }
    }
}
