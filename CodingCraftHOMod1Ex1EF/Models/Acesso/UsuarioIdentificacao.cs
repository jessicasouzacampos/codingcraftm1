using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CodingCraftHOMod1Ex1EF.Models.Acesso
{
    public class UsuarioIdentificacao : IdentityUserClaim<Guid>
    {
        public UsuarioIdentificacao()
        {

        }

        public UsuarioIdentificacao(string tipo, string valor)
        {
            ClaimType = tipo;
            ClaimValue = valor;
        }
    }
}