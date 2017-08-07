using CodingCraftHOMod1Ex1EF.Models.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public abstract class Entidade : EntidadeNaoEditavel, IEntidade
    {
        [DisplayName("Data da Última Modificação")]
        public DateTime? DataUltimaModificacao { get; set; }
        [DisplayName("Usuário da Última Modificação")]
        [StringLength(200)]
        public String UsuarioUltimaModificacao { get; set; }
    }
}