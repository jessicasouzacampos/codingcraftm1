using CodingCraftHOMod1Ex1EF.ViewModels.Acesso;
using CodingCraftHOMod1Ex1EF.ViewModels.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.ViewModels
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

        public override int SaveChanges()
        {
            try
            {
                CheckEntities();
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionsMessage = string.Concat(ex.Message, "Os erros de validações são: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionsMessage, ex.EntityValidationErrors);
            }
        }

        public override async Task<int> SaveChangesAsync()
        {
            try
            {
                CheckEntities();
                return await base.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionsMessage = string.Concat(ex.Message, "Os erros de validações são: ", fullErrorMessage);

                throw new DbEntityValidationException(exceptionsMessage, ex.EntityValidationErrors);
            }
        }

        private void CheckEntities()
        {
            var currentTime = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity != null &&
                    typeof(IEntidadeNaoEditavel).IsAssignableFrom(e.Entity.GetType())))
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Property(nameof(IEntidadeNaoEditavel.DataCriacao)) != null)
                    {
                        entry.Property(nameof(IEntidadeNaoEditavel.DataCriacao)).CurrentValue = currentTime;
                    }
                    if (entry.Property(nameof(IEntidadeNaoEditavel.UsuarioCriacao)) != null)
                    {
                        entry.Property(nameof(IEntidadeNaoEditavel.UsuarioCriacao)).CurrentValue = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "Usuario";
                    }
                }

                if (typeof(IEntidade).IsAssignableFrom(entry.Entity.GetType()) && entry.State == EntityState.Modified)
                {
                    entry.Property(nameof(IEntidade.DataCriacao)).IsModified = false;
                    entry.Property(nameof(IEntidade.UsuarioCriacao)).IsModified = false;

                    if (entry.Property(nameof(IEntidade.DataUltimaModificacao)) != null)
                    {
                        entry.Property(nameof(IEntidade.DataUltimaModificacao)).CurrentValue = currentTime;
                    }
                    if (entry.Property(nameof(IEntidade.UsuarioUltimaModificacao)) != null)
                    {
                        entry.Property(nameof(IEntidade.UsuarioUltimaModificacao)).CurrentValue = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "Usuario";
                    }
                }
            }
        }

       
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProdutoLoja> ProdutosLojas { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Compra> Compras { get; set; }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PesquisaSalva> Pesquisas { get; set; }
    }
}