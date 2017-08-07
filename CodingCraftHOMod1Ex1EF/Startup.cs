using AutoMapper;
using CodingCraftHOMod1Ex1EF.Mappers;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodingCraftHOMod1Ex1EF.Startup))]
namespace CodingCraftHOMod1Ex1EF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            RegistraMapeamentos();
        }


        public void RegistraMapeamentos()
        {
            Mapper.Initialize(mapper => {
                mapper.AddProfile<ModelToViewModel>();
                mapper.AddProfile<ViewModelToModel>();
            });
        }
    }
}
