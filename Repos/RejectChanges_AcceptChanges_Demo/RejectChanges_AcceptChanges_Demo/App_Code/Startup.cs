using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RejectChanges_AcceptChanges_Demo.Startup))]
namespace RejectChanges_AcceptChanges_Demo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
