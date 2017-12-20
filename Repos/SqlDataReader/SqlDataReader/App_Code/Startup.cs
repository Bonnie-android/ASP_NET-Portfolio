using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SqlDataReader.Startup))]
namespace SqlDataReader
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
