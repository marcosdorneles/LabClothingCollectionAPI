using System;
using System.ComponentModel.DataAnnotations;

namespace LabClothingCollectionAPI.DTO
{
	public class UsuarioColecaoDTO
	{
		[Required]
		public int UsuarioId { get; set; }
		[Required]
		public int ColecaoId { get; set; }

	}
}

