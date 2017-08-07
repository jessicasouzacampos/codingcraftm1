using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class Loja : Entidade
    {
        [Key]
        public int LojaId { get; set; }

        [Required]
        [StringLength(100)]
        [Index("IUQ_Lojas_Nome")]
        public String Nome { get; set; }

        public virtual ICollection<ProdutoLoja> LojaProdutos { get; set; }
    }
}