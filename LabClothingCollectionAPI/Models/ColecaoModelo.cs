using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabClothingCollectionAPI.Models
{
    [Table("ColecaoModelo")]
	public class ColecaoModelo
	{
        public int Id { get; set; }

        [ForeignKey("Colecao")]
        public int ColecaoId { get; set; }
        public Colecao Colecao { get; set; }

        [ForeignKey("Modelo")]
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }
    }
}

