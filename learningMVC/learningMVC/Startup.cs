using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(learningMVC.Startup))]
namespace learningMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
