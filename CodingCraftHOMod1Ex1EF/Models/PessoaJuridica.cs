using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class PessoaJuridica : Pessoa
    {
        [Required]
        [StringLength(14)]
        [Index("IUQ_PessoasJuridicas_Cnpj")]
        public String Cnpj { get; set; }
       
    }
}