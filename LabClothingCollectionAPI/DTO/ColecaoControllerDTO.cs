using System;
using LabClothingCollectionAPI.Models;

namespace LabClothingCollectionAPI.DTO
{
	public class ColecaoControllerDTO
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public double Orcamento { get; set; }
		public string Usuario { get; set; }
		public string Estacao { get; set; }
		public string Status { get; set; }
		public static implicit operator ColecaoControllerDTO(Colecao colecao)
		{
			ColecaoControllerDTO colecaoDTO = new ColecaoControllerDTO
			{
				Nome = colecao.Nome,
				Orcamento = colecao.Orcamento,
				Usuario = colecao.Usuario,
				Estacao = colecao.Estacao.ToString(),
				Status = colecao.Status.ToString(),
			};
			return colecaoDTO;
		}
	}
}

