using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LenguajesAvanzados.Startup))]
namespace LenguajesAvanzados
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
