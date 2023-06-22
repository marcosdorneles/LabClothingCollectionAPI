using System;
using LabClothingCollectionAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LabClothingCollectionAPI.DTO
{
	public class UsuarioResponseDTO
	{
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Tipo { get; set; }
        public string StatusUsuario { get; set; }
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime DataNascimento { get; set; }
        public static implicit operator UsuarioResponseDTO(Usuario usuario)
        {
            UsuarioResponseDTO usuarioDTO = new UsuarioResponseDTO
            {
                Email = usuario.email,
                Nome = usuario.Nome,
                Genero = usuario.Genero,
                Cpf = usuario.cpf,
                Telefone = usuario.Telefone,
                DataNascimento = usuario.DataNascimento,
                StatusUsuario = usuario.StatusUsuario.ToString(),
                Tipo = usuario.TipoUsuario.ToString(),
            };
            return usuarioDTO;
        }
    }
}


