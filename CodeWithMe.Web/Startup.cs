using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeWithMe.Web.Startup))]
namespace CodeWithMe.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
