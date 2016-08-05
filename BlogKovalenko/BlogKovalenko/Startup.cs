using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogKovalenko.Startup))]
namespace BlogKovalenko
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
