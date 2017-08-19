﻿using System.ComponentModel.DataAnnotations;

namespace CodingCraftHOMod1Ex1EF.Models.Enum
{
    public enum TipoPessoa
    {       
        [Display(Name = "Pessoa física")]
        PESSOAFISICA = 1,

        [Display(Name = "Pessoa jurídica")]
        PESSOAJURIDICA = 2
    }
}