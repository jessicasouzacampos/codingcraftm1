using CodingCraftHOMod1Ex1EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.ViewModels.ProdutosLojas
{
    public class ProdutosPorLoja
    {
        public Loja LojaPesquisada { get; set; }
        public List<Produto> Produtos { get; set; }
        public List<Loja> Lojas { get; set; }

    }
}