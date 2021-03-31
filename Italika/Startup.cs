using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Italika.Startup))]
namespace Italika
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
