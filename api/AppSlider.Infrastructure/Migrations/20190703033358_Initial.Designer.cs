﻿// <auto-generated />
using System;
using AppSlider.Infrastructure.EntityFrameworkDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppSlider.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190703033358_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AppSlider.Domain.Entities.Business.BusinessEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

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

                    b.Property<Guid?>("IdCategory");

                    b.Property<Guid?>("IdFather");

                    b.Property<Guid?>("IdLogo");

                    b.Property<Guid>("IdType");

                    b.Property<string>("Name")
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
                            Id = new Guid("81853d7a-41af-49b5-8bd8-83d622f7b8c4"),
                            Active = true,
                            Blocked = true,
                            ContactAddress = "",
                            ContactEmail = "",
                            ContactName = "",
                            ContactPhone = "",
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 538, DateTimeKind.Local).AddTicks(7870),
                            Description = "Franquia padrão 'MidiaFone'",
                            IdCategory = new Guid("28f8faeb-6f0d-40b8-ae04-35ab61f40c77"),
                            IdType = new Guid("73b18281-2566-49e7-bd47-2f858eb4f0cf"),
                            Name = "MidiaFone"
                        });
                });

            modelBuilder.Entity("AppSlider.Domain.Entities.Business.BusinessType", b =>
                {
                    b.Property<Guid>("Id")
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
                            Id = new Guid("73b18281-2566-49e7-bd47-2f858eb4f0cf"),
                            Blocked = true,
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 585, DateTimeKind.Local).AddTicks(1188),
                            Description = "Franquia como Tipo de Negócio.",
                            Name = "Franquia"
                        },
                        new
                        {
                            Id = new Guid("d4d5fdae-dfae-4d2b-93c3-afecb4db33c4"),
                            Blocked = true,
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 585, DateTimeKind.Local).AddTicks(1623),
                            Description = "Estabelecimento como Tipo de Negócio.",
                            Name = "Estabelecimento"
                        },
                        new
                        {
                            Id = new Guid("2abc3c81-81ec-4231-91c1-0bcd338845e7"),
                            Blocked = true,
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 585, DateTimeKind.Local).AddTicks(1786),
                            Description = "Anunciante como Tipo de Negócio.",
                            Name = "Anunciante"
                        });
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
                    b.Property<Guid>("Id")
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
                            Id = new Guid("28f8faeb-6f0d-40b8-ae04-35ab61f40c77"),
                            Blocked = true,
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 588, DateTimeKind.Local).AddTicks(7132),
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

                    b.Property<DateTime>("DataCreated");

                    b.Property<DateTime>("Expirate");

                    b.Property<Guid>("FranchiseId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Playlists");

                    b.HasData(
                        new
                        {
                            Id = new Guid("256eb97e-ebda-4310-9a30-412cfbd280ae"),
                            Active = true,
                            Blocked = true,
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 592, DateTimeKind.Local).AddTicks(1497),
                            Expirate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            FranchiseId = new Guid("81853d7a-41af-49b5-8bd8-83d622f7b8c4"),
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
                            Id = new Guid("da939422-78b5-47e0-9e0a-b27675e9e7a9"),
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1080),
                            Description = "Permissão de leitura para rotina de Usuário.",
                            Name = "AppSlider.Read.User"
                        },
                        new
                        {
                            Id = new Guid("320ac917-36f9-48e9-bbec-762f061ed5ac"),
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1262),
                            Description = "Permissão de escrita para rotina de Usuário.",
                            Name = "AppSlider.Write.User"
                        },
                        new
                        {
                            Id = new Guid("359bc08f-5945-4cdc-8395-8a9506293b7e"),
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1315),
                            Description = "Permissão de leitura para rotina de Negócio.",
                            Name = "AppSlider.Read.Business"
                        },
                        new
                        {
                            Id = new Guid("85144031-f7a3-4f19-a767-4ba91e06ebb3"),
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1363),
                            Description = "Permissão de escrita para rotina de Negócio.",
                            Name = "AppSlider.Write.Business"
                        },
                        new
                        {
                            Id = new Guid("c479f64d-6ce9-4c50-9c8e-bf58d27ed12d"),
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1410),
                            Description = "Permissão de leitura para rotina de Tipos de Negócio.",
                            Name = "AppSlider.Read.BusinessType"
                        },
                        new
                        {
                            Id = new Guid("31d181d8-5118-4d02-92e5-7d003dd24ad3"),
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1584),
                            Description = "Permissão de escrita para rotina de Tipos de Negócio.",
                            Name = "AppSlider.Write.BusinessType"
                        },
                        new
                        {
                            Id = new Guid("f50bedee-f90d-4a78-990a-2a37a8bc4c8f"),
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1685),
                            Description = "Permissão de leitura para rotina de Categoria.",
                            Name = "AppSlider.Read.Category"
                        },
                        new
                        {
                            Id = new Guid("4ee615d4-e58e-4b5c-b48a-88f3062bfa97"),
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1744),
                            Description = "Permissão de escrita para rotina de Categoria.",
                            Name = "AppSlider.Write.Category"
                        },
                        new
                        {
                            Id = new Guid("6c7e23b1-24a2-46c2-9457-80db72a8f7aa"),
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1869),
                            Description = "Permissão de leitura para rotina de Playlist.",
                            Name = "AppSlider.Read.Playlist"
                        },
                        new
                        {
                            Id = new Guid("0c9c33ed-9b69-4d72-aea2-98ea0b412889"),
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1914),
                            Description = "Permissão de escrita para rotina de Playlist.",
                            Name = "AppSlider.Write.Playlist"
                        },
                        new
                        {
                            Id = new Guid("72af5098-3216-418b-94d9-fe0769026e0d"),
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(1958),
                            Description = "Permissão de leitura para rotina de Equipamento.",
                            Name = "AppSlider.Read.Equipament"
                        },
                        new
                        {
                            Id = new Guid("13a35ba9-7647-48e8-a60f-10a502cd789c"),
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 598, DateTimeKind.Local).AddTicks(2001),
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
                            Id = new Guid("803db767-ee31-4606-b983-5454f22cbfba"),
                            Active = true,
                            Blocked = true,
                            DataCreated = new DateTime(2019, 7, 3, 0, 33, 57, 600, DateTimeKind.Local).AddTicks(4799),
                            Email = "",
                            Name = "Administrador",
                            Password = "c342ad7be7abf5228097def554f8499d4f07191f4bcf5e80d012df86659fcea6",
                            Profile = "sa",
                            Username = "admin"
                        });
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
                        .HasForeignKey("FranchiseId")
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