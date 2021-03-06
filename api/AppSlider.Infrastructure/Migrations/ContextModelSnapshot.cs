// <auto-generated />
using System;
using AppSlider.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppSlider.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ContactCity");

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
                            Id = new Guid("6615c3cc-766b-4845-90f3-5e5349c5e072"),
                            Active = true,
                            Blocked = true,
                            CNPJ = 0L,
                            ContactAddress = "",
                            ContactCity = "",
                            ContactEmail = "",
                            ContactName = "",
                            ContactPhone = "",
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 230, DateTimeKind.Local).AddTicks(4018),
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
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 267, DateTimeKind.Local).AddTicks(3411),
                            Description = "Franquia como Tipo de Negócio.",
                            Name = "Franquia"
                        },
                        new
                        {
                            Id = 2,
                            Blocked = true,
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 267, DateTimeKind.Local).AddTicks(4183),
                            Description = "Estabelecimento como Tipo de Negócio.",
                            Name = "Estabelecimento"
                        },
                        new
                        {
                            Id = 3,
                            Blocked = true,
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 267, DateTimeKind.Local).AddTicks(4264),
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
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 280, DateTimeKind.Local).AddTicks(4681),
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
                            Id = new Guid("e756ebab-407a-4965-bfa8-a72a24885829"),
                            Active = true,
                            Blocked = true,
                            BusinessId = new Guid("6615c3cc-766b-4845-90f3-5e5349c5e072"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 285, DateTimeKind.Local).AddTicks(8379),
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
                            Id = new Guid("aaa9136a-7a98-455d-a146-0659f5f31a4c"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 290, DateTimeKind.Local).AddTicks(4539),
                            Description = "Permissão de leitura para rotina de Usuário.",
                            Name = "AppSlider.Read.User"
                        },
                        new
                        {
                            Id = new Guid("f3d5d25f-2dd2-479a-a1a9-2dbd09a4ed6b"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 290, DateTimeKind.Local).AddTicks(4680),
                            Description = "Permissão de escrita para rotina de Usuário.",
                            Name = "AppSlider.Write.User"
                        },
                        new
                        {
                            Id = new Guid("e4cac319-b2dd-40fa-9cc0-0612b5139bed"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 290, DateTimeKind.Local).AddTicks(4744),
                            Description = "Permissão de leitura para rotina de Negócio.",
                            Name = "AppSlider.Read.Business"
                        },
                        new
                        {
                            Id = new Guid("a5d3abcd-5a63-43b7-a22d-10d5b9378251"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 290, DateTimeKind.Local).AddTicks(4802),
                            Description = "Permissão de escrita para rotina de Negócio.",
                            Name = "AppSlider.Write.Business"
                        },
                        new
                        {
                            Id = new Guid("f38f67b8-30a6-4b4d-bf15-a7f8cd716639"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 290, DateTimeKind.Local).AddTicks(4859),
                            Description = "Permissão de leitura para rotina de Tipos de Negócio.",
                            Name = "AppSlider.Read.BusinessType"
                        },
                        new
                        {
                            Id = new Guid("15261098-8839-4191-a3c7-a24568b461ee"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 290, DateTimeKind.Local).AddTicks(4914),
                            Description = "Permissão de escrita para rotina de Tipos de Negócio.",
                            Name = "AppSlider.Write.BusinessType"
                        },
                        new
                        {
                            Id = new Guid("697906bb-0e6c-4c5f-b8aa-fecce54daf1b"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 290, DateTimeKind.Local).AddTicks(4965),
                            Description = "Permissão de leitura para rotina de Categoria.",
                            Name = "AppSlider.Read.Category"
                        },
                        new
                        {
                            Id = new Guid("a6e2b0d6-8c28-4cfa-baaf-56e826eec20a"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 290, DateTimeKind.Local).AddTicks(5020),
                            Description = "Permissão de escrita para rotina de Categoria.",
                            Name = "AppSlider.Write.Category"
                        },
                        new
                        {
                            Id = new Guid("5fe17d1d-77b5-432a-9fb6-4e84d4d45ae1"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 290, DateTimeKind.Local).AddTicks(5074),
                            Description = "Permissão de leitura para rotina de Playlist.",
                            Name = "AppSlider.Read.Playlist"
                        },
                        new
                        {
                            Id = new Guid("73511b1f-ac5c-4939-8bd7-08b50cdec7ad"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 290, DateTimeKind.Local).AddTicks(5154),
                            Description = "Permissão de escrita para rotina de Playlist.",
                            Name = "AppSlider.Write.Playlist"
                        },
                        new
                        {
                            Id = new Guid("63ba2a59-7a58-46a1-a0a1-4685b9d46168"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 290, DateTimeKind.Local).AddTicks(5206),
                            Description = "Permissão de leitura para rotina de Equipamento.",
                            Name = "AppSlider.Read.Equipament"
                        },
                        new
                        {
                            Id = new Guid("c00159fa-54d5-44a5-baf2-8b5a8adf5ace"),
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 290, DateTimeKind.Local).AddTicks(5257),
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
                            Id = new Guid("bc72c54f-303d-4698-a102-2c164f342e98"),
                            Active = true,
                            Blocked = true,
                            DataCreated = new DateTime(2019, 9, 7, 20, 51, 56, 292, DateTimeKind.Local).AddTicks(2784),
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
