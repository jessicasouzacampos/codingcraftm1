using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace CodingCraftHOMod1Ex4Identity.Exemplos.Models
{
    public class ArmazenamentoGrupos : RoleStore<Grupo, Guid, UsuarioGrupo>
    {
        public ArmazenamentoGrupos(DbContext context) : base(context)
        {
        }
    }
}