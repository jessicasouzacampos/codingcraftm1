namespace CodingCraftHOMod1Ex1EF.Migrations
{
    using Microsoft.AspNet.Identity;
    using System.Data.Entity.Migrations;
    using Models.Acesso;
    using Models;
    using System;
    using System.Data.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new GerenciadorUsuarios(new ArmazenamentoUsuarios(context));
            var roleManager = new GerenciadorGrupos(new ArmazenamentoGrupos(context));
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new Grupo { Name = roleName , Id = Guid.NewGuid()};
                var roleresult = roleManager.Create(role);
            }
   
            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new Usuario { Id = Guid.NewGuid(), UserName = name, Email = name, DataNascimento = DateTime.Parse("1991-01-01") };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }          

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}
