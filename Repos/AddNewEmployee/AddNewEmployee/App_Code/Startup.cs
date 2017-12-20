using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AddNewEmployee.Startup))]
namespace AddNewEmployee
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
