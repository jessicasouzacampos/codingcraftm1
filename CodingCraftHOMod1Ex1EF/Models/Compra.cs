using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }

        [ForeignKey("Fornecedor")]
        public String PessoaId { get; set; }

        public DateTime Data { get; set; }

        public List<ItemCompra> Itens { get; set; }

        public virtual Pessoa Fornecedor { get; set; }
    }
}