using System.Security.Claims;
using System.Threading.Tasks;
using CodingCraftHOMod1Ex1EF.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using CodingCraftHOMod1Ex1EF.Models.Enum;

namespace CodingCraftHOMod1Ex1EF.Models.Acesso
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class Usuario : IdentityUser<Guid, UsuarioLogin, UsuarioGrupo, UsuarioIdentificacao>
    {       
        public DateTime DataNascimento { get; set; }

        public Genero Genero { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario,Guid> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
               
    }
}