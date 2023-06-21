using System;
using System.ComponentModel.DataAnnotations.Schema;
using LabClothingCollectionAPI.Models.Enums;

namespace LabClothingCollectionAPI.Models
{
	[Table("Colecao")]
	public class Colecao
	{
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public double Orcamento { get; set; }
        public string Usuario { get; set; }
        public DateTime Ano { get; set; }
        public Estacoes Estacao { get; set; }
        public StatusColecao Status { get; set; }

	}
}

