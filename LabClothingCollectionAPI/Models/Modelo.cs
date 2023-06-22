using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabClothingCollectionAPI.Models.Enums;

namespace LabClothingCollectionAPI.Models
{
	[Table("Modelo")]
	public class Modelo
	{
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Colecao { get; set; }

        [Required]
        public TipoModelo Tipo { get; set; }

        [Required]
        public LayoutModelo LayoutModelo { get; set; }

	}
}

