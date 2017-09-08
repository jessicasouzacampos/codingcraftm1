using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.ViewModels
{
    public class Fornecedor
    {
        [Key, ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}