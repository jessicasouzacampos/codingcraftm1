﻿using CodingCraftHOMod1Ex1EF.ViewModels.Acesso;
using System;

namespace CodingCraftHOMod1Ex1EF.ViewModels
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
            Id = new Guid(id);
            UserName = nome;
            Email = email;
            PhoneNumber = telefone;
        }
       
    }
}