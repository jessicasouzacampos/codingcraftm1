using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class PessoaFisica : Pessoa
    {
        [Required]
        [StringLength(14)]
        [Index("IUQ_PessoasFisicas_Cpf")]
        public String Cpf { get; set; }        
    }
}