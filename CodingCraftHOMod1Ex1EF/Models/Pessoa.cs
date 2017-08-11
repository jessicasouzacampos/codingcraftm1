using CodingCraftHOMod1Ex1EF.Models.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class Pessoa : Usuario, IEntidade
    {
        public virtual Cliente Cliente { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        [DisplayName("Data da Última Modificação")]
        public DateTime? DataUltimaModificacao { get; set; }
        [DisplayName("Usuário da Última Modificação")]
        public string UsuarioUltimaModificacao { get; set; }
        [DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }
        [DisplayName("Usuário de Criação")]
        public string UsuarioCriacao { get; set; }
    }
}