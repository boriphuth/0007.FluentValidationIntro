using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FluentValidationIntro.Startup))]
namespace FluentValidationIntro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
