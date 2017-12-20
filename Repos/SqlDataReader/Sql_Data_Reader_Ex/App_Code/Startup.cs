using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sql_Data_Reader_Ex.Startup))]
namespace Sql_Data_Reader_Ex
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
