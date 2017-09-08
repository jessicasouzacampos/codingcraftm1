using CodingCraftHOMod1Ex1EF.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingCraftHOMod1Ex1EF.ViewModels
{
    public class LojasPorCategoriaViewModel
    {
        [Display(Name = "Categoria")]
        public string NomeCategoria { get; set; }

        public IEnumerable<Categoria> Resultados { get; set; }

    }
}