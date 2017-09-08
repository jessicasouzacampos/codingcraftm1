using CodingCraftHOMod1Ex1EF.Models;
using CodingCraftHOMod1Ex1EF.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class ProdutoPesquisaViewModel : EntidadeViewModel
    {
        public ProdutoPesquisaViewModel()
        {
            Unidade = null;
        }

        [Display(Name = "Termo de Pesquisa")]
        public String TermoPesquisa { get; set; }

        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

        [Display(Name = "Valor Inicial")]
        [DataType(DataType.Currency)]
        public decimal? ValorInicial { get; set; }

        [Display(Name = "Valor Final")]
        [DataType(DataType.Currency)]
        public decimal? ValorFinal { get; set; }

        public Unidade? Unidade { get; set; }

        public IEnumerable<Produto> Resultados { get; set; }
    }
}