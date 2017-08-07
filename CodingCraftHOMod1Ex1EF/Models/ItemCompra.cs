using CodingCraftHOMod1Ex1EF.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class ItemCompra
    {
        [Key]
        public int CompraId { get; set; }
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        public decimal Quantidade { get; set; }
        public Unidade Unidade { get; set; }

        public decimal Valor { get; set; }        
        
    }
}