using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabClothingCollectionAPI.Models
{
    [Table("UsuarioColecao")]
	public class UsuarioColecao
	{
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Colecao")]
        public int ColecaoId { get; set; }
        public Colecao Colecao { get; set; }
    }
}

