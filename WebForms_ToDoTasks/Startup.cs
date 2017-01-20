using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebForms_ToDoTasks.Startup))]
namespace WebForms_ToDoTasks
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
