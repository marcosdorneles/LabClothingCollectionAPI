using System;
using LabClothingCollectionAPI.Models;

namespace LabClothingCollectionAPI.Seeds
{
	public class UsuarioSeed
	{

		public List<Usuario> Seed { get; set; } = new List<Usuario>()
		{
			new Usuario
			{
				Nome="Marcos Guilherme",
				Genero="Masculino",
				DataNascimento = new DateTime(14,07,1999),
				cpf="11111111111",
				Telefone="111111111",
				Id=0,
				email="email@teste.com",
				StatusUsuario= Models.Enums.StatusUsuario.ATIVO,
				TipoUsuario=Models.Enums.TipoUsuario.ADM
 
            }, new Usuario
			{
                Nome = "Maria Silva",
				Genero = "Feminino",
				DataNascimento = new DateTime(1985, 05, 20),
				cpf = "22222222222",
				Telefone = "222222222",
				Id = 0,
				email = "maria@teste.com",
				StatusUsuario = Models.Enums.StatusUsuario.ATIVO,
				TipoUsuario = Models.Enums.TipoUsuario.CRIADOR
            }, new Usuario
			{
                Nome = "João Santos",Genero = "Masculino",
				DataNascimento = new DateTime(1990, 12, 10),
				cpf = "33333333333",
				Telefone = "333333333",
				Id = 0,
				email = "joao@teste.com",
				StatusUsuario = Models.Enums.StatusUsuario.INATIVO,
				TipoUsuario = Models.Enums.TipoUsuario.GERENTE
            }, new Usuario
			{
                Nome = "Ana Oliveira",
				Genero = "Feminino",
				DataNascimento = new DateTime(1992, 08, 25),
				cpf = "44444444444",
				Telefone = "444444444",
				Id = 0,
				email = "ana@teste.com",
				StatusUsuario = Models.Enums.StatusUsuario.ATIVO,
				TipoUsuario = Models.Enums.TipoUsuario.GERENTE
            }, new Usuario
			{
                Nome = "Lucas Almeida",Genero = "Masculino",
				DataNascimento = new DateTime(1988, 03, 15),
				cpf = "55555555555",
				Telefone = "555555555",
				Id = 0,
				email = "lucas@teste.com",
				StatusUsuario = Models.Enums.StatusUsuario.INATIVO,
				TipoUsuario = Models.Enums.TipoUsuario.OUTRO
            }

		};

	}
}

