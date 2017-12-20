using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SqlCommandBuilder_Demo.Startup))]
namespace SqlCommandBuilder_Demo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
