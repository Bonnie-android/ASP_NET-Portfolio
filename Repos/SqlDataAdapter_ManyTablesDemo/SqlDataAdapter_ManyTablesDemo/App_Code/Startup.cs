using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SqlDataAdapter_ManyTablesDemo.Startup))]
namespace SqlDataAdapter_ManyTablesDemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
