using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodingCraftHOMod1Ex1EF.Models.Acesso
{
    public class ArmazenamentoGrupos : RoleStore<Grupo, Guid, UsuarioGrupo>
    {
        public ArmazenamentoGrupos(DbContext context) : base(context)
        {
        }
    }
}