using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class Cliente
    {
        [Key, ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}