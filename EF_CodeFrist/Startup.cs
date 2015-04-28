using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EF_CodeFirst.Startup))]
namespace EF_CodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
