using CodingCraftHOMod1Ex1EF.ViewModels.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodingCraftHOMod1Ex1EF.ViewModels
{
    public abstract class EntidadeNaoEditavel : IEntidadeNaoEditavel
    {
        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }
        [DisplayName("Usuário de Criação")]
        [StringLength(200)]
        public String UsuarioCriacao { get; set; }
    }
}