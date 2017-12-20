using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataSqlAdapter_Demo.Startup))]
namespace DataSqlAdapter_Demo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
