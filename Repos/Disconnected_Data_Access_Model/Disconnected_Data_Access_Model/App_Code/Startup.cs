using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Disconnected_Data_Access_Model.Startup))]
namespace Disconnected_Data_Access_Model
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
