using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Board.Startup))]
namespace Board
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
