using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.Models.Acesso
{
    public class Grupo : IdentityRole<Guid, UsuarioGrupo>
    {
    }
}