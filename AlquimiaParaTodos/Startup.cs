using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlquimiaParaTodos.Startup))]
namespace AlquimiaParaTodos
{
    public partial class Startup
    {
        public static string AppDescriptor = "Mezcla Perfecta";

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
