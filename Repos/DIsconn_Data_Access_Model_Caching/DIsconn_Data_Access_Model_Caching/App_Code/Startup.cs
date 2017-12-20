using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DIsconn_Data_Access_Model_Caching.Startup))]
namespace DIsconn_Data_Access_Model_Caching
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
