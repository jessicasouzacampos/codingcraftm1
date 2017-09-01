using Owin;

namespace CodingCraftHOMod1Ex4Identity.Exemplos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
