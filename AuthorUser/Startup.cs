using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthorUser.Startup))]
namespace AuthorUser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
