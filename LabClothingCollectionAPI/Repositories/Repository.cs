using System;
using LabClothingCollectionAPI.Models;
using LabClothingCollectionAPI.Seeds;
using Microsoft.EntityFrameworkCore;

namespace LabClothingCollectionAPI.Repositories
{
	public class Repository : DbContext
	{
        public Repository(DbContextOptions options) : base(options)
        {

        }

        public Repository()
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Colecao> ColecaoModels { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<UsuarioColecao> UsuarioColecaoModels { get; set; }
        public virtual DbSet<ColecaoModelo> ColecaoModelos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Nome = "Marcos Guilherme",
                Genero = "Masculino",
                DataNascimento = new DateTime(1999, 07, 14),
                cpf = "11111111111",
                Telefone = "111111111",
                Id = 1,
                email = "email@teste.com",
                StatusUsuario = Models.Enums.StatusUsuario.ATIVO,
                TipoUsuario = Models.Enums.TipoUsuario.ADM

            }, new Usuario
            {
                Nome = "Maria Silva",
                Genero = "Feminino",
                DataNascimento = new DateTime(1985, 05, 20),
                cpf = "22222222222",
                Telefone = "222222222",
                Id=2,
                email = "maria@teste.com",
                StatusUsuario = Models.Enums.StatusUsuario.ATIVO,
                TipoUsuario = Models.Enums.TipoUsuario.CRIADOR
            }, new Usuario
            {
                Nome = "João Santos",
                Genero = "Masculino",
                DataNascimento = new DateTime(1990, 12, 05),
                cpf = "33333333333",
                Telefone = "333333333",
                Id=3,
                email = "joao@teste.com",
                StatusUsuario = Models.Enums.StatusUsuario.INATIVO,
                TipoUsuario = Models.Enums.TipoUsuario.GERENTE
            }, new Usuario
            {
                Nome = "Ana Oliveira",
                Genero = "Feminino",
                DataNascimento = new DateTime(1995, 08, 14),
                cpf = "44444444444",
                Telefone = "444444444",
                Id = 4,
                email = "ana@teste.com",
                StatusUsuario = Models.Enums.StatusUsuario.ATIVO,
                TipoUsuario = Models.Enums.TipoUsuario.GERENTE
            }, new Usuario
            {
                Nome = "Lucas Almeida",
                Genero = "Masculino",
                DataNascimento = new DateTime(1998, 03, 09),
                cpf = "55555555555",
                Telefone = "555555555",
                Id = 5,
                email = "lucas@teste.com",
                StatusUsuario = Models.Enums.StatusUsuario.INATIVO,
                TipoUsuario = Models.Enums.TipoUsuario.OUTRO
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ServerConnection");
            }
        }
    }
}

