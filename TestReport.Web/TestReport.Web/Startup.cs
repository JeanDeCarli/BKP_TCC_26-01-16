using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestReport.Web.Startup))]
namespace TestReport.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
