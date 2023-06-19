using System;
using System.ComponentModel.DataAnnotations.Schema;
using LabClothingCollectionAPI.Models.Enums;

namespace LabClothingCollectionAPI.Models
{
	[Table("Modelo")]
	public class Modelo
	{
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoModelo Tipo { get; set; }
        public LayoutModelo LayoutModelo { get; set; }

	}
}

