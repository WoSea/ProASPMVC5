using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ch14_DebuggingDemo.Startup))]
namespace Ch14_DebuggingDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
