using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.ViewModels.Acesso
{
    public class ArmazenamentoUsuarios : UserStore<Usuario, Grupo, Guid, UsuarioLogin, UsuarioGrupo, UsuarioIdentificacao>
    {
        public ArmazenamentoUsuarios(DbContext context) : base(context)
        {
        }
    }
}