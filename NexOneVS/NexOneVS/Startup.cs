using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NexOneVS.Startup))]
namespace NexOneVS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
