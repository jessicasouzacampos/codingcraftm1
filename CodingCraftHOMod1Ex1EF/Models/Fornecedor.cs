using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class Fornecedor
    {
        [Key, ForeignKey("Pessoa")]
        public String PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}