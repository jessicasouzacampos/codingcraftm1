using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodingCraftHOMod1Ex1EF.ViewModels
{
    public abstract class EntidadeViewModel : EntidadeNaoEditavelViewModel
    {
        [DisplayName("Data da Última Modificação Inicial")]
        public DateTime? DataUltimaModificacaoInicial { get; set; }
        [DisplayName("Data da Última Modificação Final")]
        public DateTime? DataUltimaModificacaoFinal { get; set; }
        [DisplayName("Usuário da Última Modificação")]
        [StringLength(200)]
        public String UsuarioUltimaModificacao { get; set; }
    }
}