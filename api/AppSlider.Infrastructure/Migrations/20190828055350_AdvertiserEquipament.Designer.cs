// <auto-generated />
using System;
using AppSlider.Infrastructure.DataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppSlider.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190828055350_AdvertiserEquipament")]
    partial class AdvertiserEquipament
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AppSlider.Domain.Entities.Business.Advertiser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCreated");

                    b.HasKey("Id");

                    b.ToTable("Advertisers");
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Business.AdvertiserEquipament", b =>
                {
                    b.Property<Guid>("IdAdvertiser");

                    b.Property<Guid>("IdEquipament");

                    b.HasKey("IdAdvertiser", "IdEquipament");

                    b.HasIndex("IdEquipament");

                    b.ToTable("AdvertiserEquipament");
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Business.AdvertiserEstablishments", b =>
                {
                    b.Property<Guid>("IdAdvertiser");

                    b.Property<Guid>("IdEstablishment");

                    b.HasKey("IdAdvertiser", "IdEstablishment");

                    b.HasIndex("IdEstablishment");

                    b.ToTable("AdvertiserEstablishments");
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Business.BusinessEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

                    b.Property<long?>("CNPJ");

                    b.Property<string>("ContactAddress")
                        .HasMaxLength(300);

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(200);

                    b.Property<string>("ContactName")
                        .HasMaxLength(200);

                    b.Property<string>("ContactPhone")
                        .HasMaxLength(50);

                    b.Property<DateTime>("DataCreated");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("ExpirationDate");

                    b.Property<byte[]>("File");

                    b.Property<int?>("IdCategory");

                    b.Property<Guid?>("IdFather");

                    b.Property<Guid?>("IdLogo");

                    b.Property<int>("IdType");

                    b.Property<string>("LegalName")
                        .HasColumnName("Name")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdFather");

                    b.HasIndex("IdLogo");

                    b.HasIndex("IdType");

                    b.ToTable("Business");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a3915d4e-b8ad-4d11-8418-58fc74825993"),
                            Active = true,
                            Blocked = true,
                            CNPJ = 0L,
                            ContactAddress = "",
                            ContactEmail = "",
                            ContactName = "",
                            ContactPhone = "",
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 153, DateTimeKind.Local).AddTicks(5798),
                            Description = "Franquia padrão 'MidiaFone'",
                            IdCategory = 1,
                            IdType = 1,
                            LegalName = "MidiaFone"
                        });
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Business.BusinessType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCreated");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("BusinessTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Blocked = true,
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 195, DateTimeKind.Local).AddTicks(6769),
                            Description = "Franquia como Tipo de Negócio.",
                            Name = "Franquia"
                        },
                        new
                        {
                            Id = 2,
                            Blocked = true,
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 195, DateTimeKind.Local).AddTicks(7691),
                            Description = "Estabelecimento como Tipo de Negócio.",
                            Name = "Estabelecimento"
                        },
                        new
                        {
                            Id = 3,
                            Blocked = true,
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 195, DateTimeKind.Local).AddTicks(7782),
                            Description = "Anunciante como Tipo de Negócio.",
                            Name = "Anunciante"
                        });
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Business.Establishment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCreated");

                    b.HasKey("Id");

                    b.ToTable("Establishments");
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.BusinessPlayLists.BusinessPlayList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCreated");

                    b.Property<Guid>("IdBusiness");

                    b.Property<Guid>("IdPlayList");

                    b.HasKey("Id");

                    b.HasIndex("IdBusiness");

                    b.HasIndex("IdPlayList");

                    b.ToTable("BusinessPlaylists");
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCreated");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Blocked = true,
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 210, DateTimeKind.Local).AddTicks(2951),
                            Description = "Categoria MidiaFone.",
                            Name = "MidiaFone"
                        });
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Equipaments.Equipament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCreated");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<Guid?>("IdEstablishment");

                    b.Property<Guid>("IdFranchise");

                    b.Property<Guid?>("IdPlaylist");

                    b.Property<string>("MacAddress")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("IdEstablishment");

                    b.HasIndex("IdFranchise");

                    b.HasIndex("IdPlaylist");

                    b.HasIndex("MacAddress");

                    b.ToTable("Equipaments");
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Files.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Data");

                    b.Property<DateTime>("DataCreated");

                    b.Property<string>("MineType");

                    b.Property<string>("Name");

                    b.Property<long>("Size");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.PlayLists.Playlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("Blocked");

                    b.Property<Guid>("BusinessId");

                    b.Property<DateTime>("DataCreated");

                    b.Property<DateTime>("Expirate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Playlists");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c6ac8f9b-8a80-46b2-90d1-485003d09386"),
                            Active = true,
                            Blocked = true,
                            BusinessId = new Guid("a3915d4e-b8ad-4d11-8418-58fc74825993"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 216, DateTimeKind.Local).AddTicks(5909),
                            Expirate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            Name = "Curiosidades MidiaFone"
                        });
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.PlayLists.PlaylistFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCreated");

                    b.Property<short>("Duration");

                    b.Property<Guid>("IdFile");

                    b.Property<Guid>("IdPlayList");

                    b.Property<int>("PlaylistFileType");

                    b.HasKey("Id");

                    b.HasIndex("IdFile");

                    b.HasIndex("IdPlayList");

                    b.ToTable("PlaylistFiles");
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Roles.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCreated");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("46044527-e348-43e4-a7e7-2bc5bbcdb680"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 221, DateTimeKind.Local).AddTicks(7695),
                            Description = "Permissão de leitura para rotina de Usuário.",
                            Name = "AppSlider.Read.User"
                        },
                        new
                        {
                            Id = new Guid("f9eee27d-c2b1-4c9a-b989-ef318bc66254"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 221, DateTimeKind.Local).AddTicks(7821),
                            Description = "Permissão de escrita para rotina de Usuário.",
                            Name = "AppSlider.Write.User"
                        },
                        new
                        {
                            Id = new Guid("95ab08e5-1e53-4cc3-a973-9f1c34079895"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 221, DateTimeKind.Local).AddTicks(7883),
                            Description = "Permissão de leitura para rotina de Negócio.",
                            Name = "AppSlider.Read.Business"
                        },
                        new
                        {
                            Id = new Guid("06e743e7-90ea-4edb-95c0-110da453a2aa"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 221, DateTimeKind.Local).AddTicks(7943),
                            Description = "Permissão de escrita para rotina de Negócio.",
                            Name = "AppSlider.Write.Business"
                        },
                        new
                        {
                            Id = new Guid("def27a16-6509-4ac9-916e-de8fc791ffa6"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 221, DateTimeKind.Local).AddTicks(8049),
                            Description = "Permissão de leitura para rotina de Tipos de Negócio.",
                            Name = "AppSlider.Read.BusinessType"
                        },
                        new
                        {
                            Id = new Guid("b29c176e-7832-4572-93e8-d87bddaed754"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 221, DateTimeKind.Local).AddTicks(8104),
                            Description = "Permissão de escrita para rotina de Tipos de Negócio.",
                            Name = "AppSlider.Write.BusinessType"
                        },
                        new
                        {
                            Id = new Guid("f581ea5c-e28c-43ba-8ea4-90d73d9a304b"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 221, DateTimeKind.Local).AddTicks(8159),
                            Description = "Permissão de leitura para rotina de Categoria.",
                            Name = "AppSlider.Read.Category"
                        },
                        new
                        {
                            Id = new Guid("24aa6860-65b0-4019-90bc-d928f7021d99"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 221, DateTimeKind.Local).AddTicks(8212),
                            Description = "Permissão de escrita para rotina de Categoria.",
                            Name = "AppSlider.Write.Category"
                        },
                        new
                        {
                            Id = new Guid("1442dfee-e9cf-498a-9290-bccbd5a3340f"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 221, DateTimeKind.Local).AddTicks(8266),
                            Description = "Permissão de leitura para rotina de Playlist.",
                            Name = "AppSlider.Read.Playlist"
                        },
                        new
                        {
                            Id = new Guid("2173dc5d-9dac-4529-a1fe-7075e2717958"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 221, DateTimeKind.Local).AddTicks(8319),
                            Description = "Permissão de escrita para rotina de Playlist.",
                            Name = "AppSlider.Write.Playlist"
                        },
                        new
                        {
                            Id = new Guid("26433585-3981-40bc-94a8-b554d4c3985c"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 221, DateTimeKind.Local).AddTicks(8372),
                            Description = "Permissão de leitura para rotina de Equipamento.",
                            Name = "AppSlider.Read.Equipament"
                        },
                        new
                        {
                            Id = new Guid("4c0c9f3a-8d03-48ed-bba3-be93283cb9e2"),
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 221, DateTimeKind.Local).AddTicks(8423),
                            Description = "Permissão de escrita para rotina de Equipamento.",
                            Name = "AppSlider.Write.Equipament"
                        });
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCreated");

                    b.Property<string>("Email");

                    b.Property<string>("Franchises");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<string>("Password");

                    b.Property<string>("Profile");

                    b.Property<string>("Roles");

                    b.Property<string>("Username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b67ea9ee-9e8d-4de0-8f65-6d6ab029f645"),
                            Active = true,
                            Blocked = true,
                            DataCreated = new DateTime(2019, 8, 28, 2, 53, 50, 223, DateTimeKind.Local).AddTicks(7609),
                            Email = "",
                            Name = "Administrador",
                            Password = "c342ad7be7abf5228097def554f8499d4f07191f4bcf5e80d012df86659fcea6",
                            Profile = "sa",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Business.AdvertiserEquipament", b =>
                {
                    b.HasOne("AppSlider.Domain.Entities.Business.Advertiser", "Advertiser")
                        .WithMany("AdvertisersEquipament")
                        .HasForeignKey("IdAdvertiser")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppSlider.Domain.Entities.Equipaments.Equipament", "Equipament")
                        .WithMany("AdvertisersEquipament")
                        .HasForeignKey("IdEquipament")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Business.AdvertiserEstablishments", b =>
                {
                    b.HasOne("AppSlider.Domain.Entities.Business.Advertiser", "Advertiser")
                        .WithMany("AdvertisersEstablishments")
                        .HasForeignKey("IdAdvertiser")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppSlider.Domain.Entities.Business.Establishment", "Establishment")
                        .WithMany("AdvertisersEstablishments")
                        .HasForeignKey("IdEstablishment")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Business.BusinessEntity", b =>
                {
                    b.HasOne("AppSlider.Domain.Entities.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory");

                    b.HasOne("AppSlider.Domain.Entities.Business.BusinessEntity", "BusinessEntityFather")
                        .WithMany("ChildrenBusinessEntity")
                        .HasForeignKey("IdFather");

                    b.HasOne("AppSlider.Domain.Entities.Files.File", "Logo")
                        .WithMany()
                        .HasForeignKey("IdLogo");

                    b.HasOne("AppSlider.Domain.Entities.Business.BusinessType", "Type")
                        .WithMany()
                        .HasForeignKey("IdType")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.BusinessPlayLists.BusinessPlayList", b =>
                {
                    b.HasOne("AppSlider.Domain.Entities.Business.BusinessEntity", "Business")
                        .WithMany()
                        .HasForeignKey("IdBusiness")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppSlider.Domain.Entities.PlayLists.Playlist", "PlayList")
                        .WithMany()
                        .HasForeignKey("IdPlayList")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Equipaments.Equipament", b =>
                {
                    b.HasOne("AppSlider.Domain.Entities.Business.BusinessEntity", "Establishment")
                        .WithMany()
                        .HasForeignKey("IdEstablishment");

                    b.HasOne("AppSlider.Domain.Entities.Business.BusinessEntity", "Franchise")
                        .WithMany()
                        .HasForeignKey("IdFranchise")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppSlider.Domain.Entities.PlayLists.Playlist", "PlayList")
                        .WithMany()
                        .HasForeignKey("IdPlaylist");
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.PlayLists.Playlist", b =>
                {
                    b.HasOne("AppSlider.Domain.Entities.Business.BusinessEntity", "Franchise")
                        .WithMany("Playlists")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.PlayLists.PlaylistFile", b =>
                {
                    b.HasOne("AppSlider.Domain.Entities.Files.File", "File")
                        .WithMany()
                        .HasForeignKey("IdFile")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AppSlider.Domain.Entities.PlayLists.Playlist", "Playlist")
                        .WithMany("PlaylistFiles")
                        .HasForeignKey("IdPlayList")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
