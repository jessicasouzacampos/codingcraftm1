using CodingCraftHOMod1Ex1EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingCraftHOMod1Ex1EF.ViewModels
{
    public class ProdutosPorLojaViewModel
    {
        [Display(Name = "Loja")]
        public int? LojaId { get; set; }

        public IEnumerable<ProdutosViewModel> Resultados { get; set; }

    }

    public class LojasPorCategoriaViewModel
    {
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

        public IEnumerable<LojasViewModel> Resultados { get; set; }

    }

    public class ProdutosViewModel
    {
        public ProdutosViewModel(int produtoId, int categoriaId, String nome, decimal valor, decimal quantidade)
        {
            ProdutoId = produtoId;
            CategoriaId = categoriaId;
            Nome = nome;
            Valor = valor;
            Quantidade = quantidade;
        }

        public int ProdutoId { get; set; }
        public int CategoriaId { get; set; }

        [StringLength(200)]
        public String Nome { get; set; }

        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        public decimal Quantidade { get; set; }
    }

    public class LojasViewModel
    {
        public LojasViewModel(int lojaId, String nome, decimal quantidade)
        {
            LojaId = lojaId;           
            Nome = nome;
            Quantidade = quantidade;
        }

        public int LojaId { get; set; }    

        [StringLength(200)]
        public String Nome { get; set; }

        public decimal Quantidade { get; set; }

    }
}