using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodingCraftHOMod1Ex1EF.ViewModels
{
    public abstract class EntidadeNaoEditavelViewModel
    {
        [DisplayName("Data de Criação Inicial")]
        public DateTime? DataCriacaoInicial { get; set; }
        [DisplayName("Data de Criação Final")]
        public DateTime? DataCriacaoFinal { get; set; }
        [DisplayName("Usuário de Criação")]
        [StringLength(200)]
        public String UsuarioCriacao { get; set; }
    }
}