using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabClothingCollectionAPI.Models.Enums;

namespace LabClothingCollectionAPI.Models
{
	[Table("Usuario")]
	public class Usuario : Pessoa
	{
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public StatusUsuario StatusUsuario { get; set; }

        [Required]
        public TipoUsuario TipoUsuario { get; set; }

	}


}

