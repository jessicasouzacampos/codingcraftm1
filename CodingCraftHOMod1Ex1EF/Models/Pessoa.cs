using CodingCraftHOMod1Ex1EF.Models.Interfaces;
using System;
using System.ComponentModel;
using CodingCraftHOMod1Ex1EF.ViewModels;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class Pessoa : Usuario
    {
        public virtual Cliente Cliente { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public Pessoa()
        {

        }

        public Pessoa(String id, String nome, String email, String telefone)
        {
            Id = id;
            UserName = nome;
            Email = email;
            PhoneNumber = telefone;
        }
       
    }
}