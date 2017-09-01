using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace CodingCraftHOMod1Ex4Identity.Exemplos.Models
{
    public class ArmazenamentoUsuarios : UserStore<Usuario, Grupo, Guid, UsuarioLogin, UsuarioGrupo, UsuarioIdentificacao>
    {
        public ArmazenamentoUsuarios(DbContext context) : base(context)
        {
        }
    }
}