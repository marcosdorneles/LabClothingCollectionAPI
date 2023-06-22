using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LabClothingCollectionAPI.Models
{
	public class Pessoa
	{
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório" )]
        [MaxLength(30,ErrorMessage ="O campo não pode exceder 30 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Genero { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(11,ErrorMessage ="O campo não pode exercer 11 caracteres")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }


	}
}

