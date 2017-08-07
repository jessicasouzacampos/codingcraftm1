using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class Compra
    {
        [Key]
        public int CompraId { get; set; }

        public DateTime Data { get; set; }

        public List<ItemCompra> Itens { get; set; }
    }
}