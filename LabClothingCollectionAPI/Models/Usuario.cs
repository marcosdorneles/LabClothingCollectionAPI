using System;
using System.ComponentModel.DataAnnotations.Schema;
using LabClothingCollectionAPI.Models.Enums;

namespace LabClothingCollectionAPI.Models
{
	[Table("Usuario")]
	public class Usuario : Pessoa
	{
        public int Id { get; set; }
        public string email { get; set; }
        public StatusUsuario StatusUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

	}
}

