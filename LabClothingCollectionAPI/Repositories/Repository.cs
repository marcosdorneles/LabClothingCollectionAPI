using System;
using LabClothingCollectionAPI.Models;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ServerConnection");
            }
        }
    }
}

