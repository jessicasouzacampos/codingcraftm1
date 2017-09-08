using CodingCraftHOMod1Ex1EF.ViewModels.Acesso;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.ViewModels
{
    public class PesquisaSalva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataHoraPesquisa { get; set; }

        [Required]
        public string Filtros { get; set; }

        [Required]
        public string Pesquisa { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario {get; set;}
    }
}