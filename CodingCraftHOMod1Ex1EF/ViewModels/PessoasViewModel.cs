using CodingCraftHOMod1Ex1EF.Models;
using CodingCraftHOMod1Ex1EF.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class PessoasPorDadosBasicosViewModel
    {       
        [Display(Name = "Tipo")]
        public TipoPessoa? Tipo { get; set; }
       
        [Display(Name = "Nome/CPF/CNPJ")]        
        public String TermoPesquisa { get; set; }

        public List<Pessoa> Resultados { get; set; }                               
    }

    public class PessoaViewModel {

        public PessoaViewModel()
        {

        }

        public PessoaViewModel(String id, String nome, String cpf, String cnpj, String email, String telefone)
        {
            Id = id;
            UserName = nome;
            Email = email;
            PhoneNumber = telefone;
            Cpf = cpf;
            Cnpj = cnpj;
        }
        
        [Required]
        [Display(Name = "Código")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string UserName { get; set; }
        
        [Display(Name = "CPF")]
        [StringLength(14)]
        public String Cpf { get; set; }
    
        [Display(Name = "CNPJ")]
        [StringLength(14)]
        public String Cnpj { get; set; }

        [Required]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        public String PhoneNumber { get; set; }
    }

}