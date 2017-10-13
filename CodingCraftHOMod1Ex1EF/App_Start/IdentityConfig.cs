using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using CodingCraftHOMod1Ex1EF.Models;
using CodingCraftHOMod1Ex1EF.Models.Acesso;

namespace CodingCraftHOMod1Ex1EF
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class GerenciadorUsuarios : UserManager<Usuario, Guid>
    {
        public GerenciadorUsuarios(IUserStore<Usuario,Guid> store)
            : base(store)
        {
        }

        public static GerenciadorUsuarios Create(IdentityFactoryOptions<GerenciadorUsuarios> options,
            IOwinContext context)
        {
            var manager = new GerenciadorUsuarios(new ArmazenamentoUsuarios(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<Usuario,Guid>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<Usuario, Guid>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<Usuario, Guid>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<Usuario, Guid>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class GerenciadorGrupos : RoleManager<Grupo, Guid>
    {
        public GerenciadorGrupos(IRoleStore<Grupo,Guid> roleStore)
            : base(roleStore)
        {
        }

        public static GerenciadorGrupos Create(IdentityFactoryOptions<GerenciadorGrupos> options, IOwinContext context)
        {
            return new GerenciadorGrupos(new ArmazenamentoGrupos(context.Get<ApplicationDbContext>()));
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext> 
    {
        protected override void Seed(ApplicationDbContext context) {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db) {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<GerenciadorUsuarios>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<GerenciadorGrupos>();
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null) {
                role = new Grupo { Name = roleName};
                var roleresult = roleManager.Create(role);
            }
            var dt = DateTime.Parse("1991-01-01");
            var user = userManager.FindByName(name);
            if (user == null) {
                user = new Usuario { UserName = name, Email = name , DataNascimento = dt };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name)) {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }

    public class ApplicationSignInManager : SignInManager<Usuario, Guid>
    {
        public ApplicationSignInManager(GerenciadorUsuarios userManager, IAuthenticationManager authenticationManager) : 
            base(userManager, authenticationManager) { }

        public override async Task<ClaimsIdentity> CreateUserIdentityAsync(Usuario user)
        {
            ClaimsIdentity claimIdentity = await base.CreateUserIdentityAsync(user);            

            foreach(var role in user.Roles)
            {
                claimIdentity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
            }                       

            return claimIdentity;
        }
        

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<GerenciadorUsuarios>(), context.Authentication);
        }
    }
}