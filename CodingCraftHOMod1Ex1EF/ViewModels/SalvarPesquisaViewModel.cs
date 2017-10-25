using CodingCraftHOMod1Ex1EF.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.ViewModels
{
    public class SalvarPesquisaViewModel
    {
        [Required(ErrorMessage = "É obrigatório selecionar o formato")]
        public Formato FormatoEscolhido { get; set; } 
    }
}