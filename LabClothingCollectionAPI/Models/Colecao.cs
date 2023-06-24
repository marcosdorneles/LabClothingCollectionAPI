using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabClothingCollectionAPI.Models.Enums;

namespace LabClothingCollectionAPI.Models
{
	[Table("Colecao")]
	public class Colecao
	{
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public double Orcamento { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime Ano { get; set; }

        [Required]
        public Estacoes Estacao { get; set; }

        [Required]
        public StatusColecao Status { get; set; }

	}
}

