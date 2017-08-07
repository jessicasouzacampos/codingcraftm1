using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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