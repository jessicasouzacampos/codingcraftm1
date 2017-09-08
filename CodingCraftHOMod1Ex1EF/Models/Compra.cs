using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.ViewModels
{
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }

        [ForeignKey("Fornecedor")]
        public Guid PessoaId { get; set; }

        public DateTime Data { get; set; }

        public List<ItemCompra> Itens { get; set; }

        public virtual Pessoa Fornecedor { get; set; }
    }
}