using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace CodingCraftHOMod1Ex4Identity.Exemplos.Models
{

    public class ApplicationDbContext : IdentityDbContext<Usuario, Grupo, Guid, UsuarioLogin, UsuarioGrupo, UsuarioIdentificacao>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            // Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios", "dbo").Property(p => p.Id).HasColumnName("Id");

            modelBuilder.Entity<UsuarioGrupo>()
                .HasKey(r => new { r.UserId, r.RoleId })
                .ToTable("UsuariosGrupos");

            modelBuilder.Entity<UsuarioLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("UsuariosLogins");

            modelBuilder.Entity<Grupo>()
                .HasKey(g => new { g.Id })
                .ToTable("Grupos");

            modelBuilder.Entity<UsuarioIdentificacao>()
                .HasKey(ui => new { ui.Id })
                .ToTable("UsuariosIdentificacoes");
        }
    }
}