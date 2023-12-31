﻿// <auto-generated />
using System;
using LabClothingCollectionAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabClothingCollectionAPI.Migrations
{
    [DbContext(typeof(Repository))]
    partial class RepositoryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LabClothingCollectionAPI.Models.Colecao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Ano")
                        .HasColumnType("datetime2");

                    b.Property<int>("Estacao")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Orcamento")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colecao");
                });

            modelBuilder.Entity("LabClothingCollectionAPI.Models.ColecaoModelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ColecaoId")
                        .HasColumnType("int");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColecaoId");

                    b.HasIndex("ModeloId");

                    b.ToTable("ColecaoModelo");
                });

            modelBuilder.Entity("LabClothingCollectionAPI.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Colecao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LayoutModelo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Modelo");
                });

            modelBuilder.Entity("LabClothingCollectionAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("StatusUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNascimento = new DateTime(1999, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            Nome = "Marcos Guilherme",
                            StatusUsuario = 1,
                            Telefone = "111111111",
                            TipoUsuario = 0,
                            cpf = "11111111111",
                            email = "email@teste.com"
                        },
                        new
                        {
                            Id = 2,
                            DataNascimento = new DateTime(1985, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Feminino",
                            Nome = "Maria Silva",
                            StatusUsuario = 1,
                            Telefone = "222222222",
                            TipoUsuario = 2,
                            cpf = "22222222222",
                            email = "maria@teste.com"
                        },
                        new
                        {
                            Id = 3,
                            DataNascimento = new DateTime(1990, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            Nome = "João Santos",
                            StatusUsuario = 2,
                            Telefone = "333333333",
                            TipoUsuario = 1,
                            cpf = "33333333333",
                            email = "joao@teste.com"
                        },
                        new
                        {
                            Id = 4,
                            DataNascimento = new DateTime(1995, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Feminino",
                            Nome = "Ana Oliveira",
                            StatusUsuario = 1,
                            Telefone = "444444444",
                            TipoUsuario = 1,
                            cpf = "44444444444",
                            email = "ana@teste.com"
                        },
                        new
                        {
                            Id = 5,
                            DataNascimento = new DateTime(1998, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "Masculino",
                            Nome = "Lucas Almeida",
                            StatusUsuario = 2,
                            Telefone = "555555555",
                            TipoUsuario = 3,
                            cpf = "55555555555",
                            email = "lucas@teste.com"
                        });
                });

            modelBuilder.Entity("LabClothingCollectionAPI.Models.UsuarioColecao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ColecaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColecaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioColecao");
                });

            modelBuilder.Entity("LabClothingCollectionAPI.Models.ColecaoModelo", b =>
                {
                    b.HasOne("LabClothingCollectionAPI.Models.Colecao", "Colecao")
                        .WithMany()
                        .HasForeignKey("ColecaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabClothingCollectionAPI.Models.Modelo", "Modelo")
                        .WithMany()
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colecao");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("LabClothingCollectionAPI.Models.UsuarioColecao", b =>
                {
                    b.HasOne("LabClothingCollectionAPI.Models.Colecao", "Colecao")
                        .WithMany()
                        .HasForeignKey("ColecaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabClothingCollectionAPI.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colecao");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
