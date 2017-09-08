using System;

namespace CodingCraftHOMod1Ex1EF.ViewModels.Interfaces
{
    public interface IEntidade : IEntidadeNaoEditavel
    {
        DateTime? DataUltimaModificacao { get; set; }
        String UsuarioUltimaModificacao { get; set; }
    }
}
