using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Next_Result_Demo.Startup))]
namespace Next_Result_Demo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
