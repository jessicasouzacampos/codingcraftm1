using CodingCraftHOMod1Ex1EF.Models;
using CodingCraftHOMod1Ex1EF.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingCraftHOMod1Ex1EF.ViewModels
{
    public class ProdutosPorLojaViewModel
    {     
        [Display(Name = "Loja")]
        public string  NomeLoja { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o local onde deseja salvar o arquivo")]
        public string LocalArquivo { get; set; }

        [Required(ErrorMessage ="É obrigatório selecionar o formato")]
        public Formato FormatoEscolhido { get; set; }

        public IEnumerable<ProdutosViewModel> Resultados { get; set; }

    }

    public class LojasPorCategoriaViewModel
    {
        [Display(Name = "Categoria")]
        public string NomeCategoria { get; set; }

        public IEnumerable<LojasViewModel> Resultados { get; set; }

    }

    public class ProdutosViewModel
    {
        public ProdutosViewModel()
        {

        }
        public ProdutosViewModel(int produtoId, int categoriaId, String nome, decimal valor, decimal quantidade, int prodLojaId)
        {
            ProdutoId = produtoId;
            CategoriaId = categoriaId;
            Nome = nome;
            Valor = valor;
            Quantidade = quantidade;
            ProdutoLojaId = prodLojaId;
        }

        [Display(Name = "Codigo do produto")]
        public int ProdutoId { get; set; }

        public int ProdutoLojaId { get; set; }

        [Display(Name = "Codigo da categoria")]
        public int CategoriaId { get; set; }

        [StringLength(200)]
        [Display(Name ="Nome")]
        public String Nome { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
        public decimal Valor { get; set; }

        [Display(Name = "Quantidade")]
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