using CodingCraftHOMod1Ex1EF.Atributos;
using CodingCraftHOMod1Ex1EF.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.ViewModels
{
    public class Contato
    {
        [MaxLength(128)]
        [Display(Name ="Código identificador")]
        public string  Id { get; set; }

        [MaxLength(200)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [MaxLength(256)]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        //[MaxLength(10)]
        //[MinLength(8, ErrorMessage ="A senha deve conter no mínimo 8 caracteres.")]
        
        [DataType(DataType.Password)]
        [Password(ErrorMessage = "A senha deve conter pelo menos 1 letra maiúcula, 1 letra minúscula e 1 número.")]
        public string Password { get; set; }

        [Display(Name = "Telefone")]
        [Phone]
        public string Telefone { get; set; }

        [Display(Name = "CPF")]
        [Cpf]
        public string Cpf { get; set; }

        [Display(Name = "CNPJ")]
        [Cnpj]
        public string Cnpj { get; set; }

        [Display(Name = "Tipo")]
        public TipoPessoa TipoPessoa { get; set; }


    }
}