using System.Configuration;

namespace WebForms_ToDoTasks.DataAccess
{
    public class ToDoTasksDbContext
    {
        public string connectionString;
        public ToDoTasksDbContext()
        {
            connectionString = ConfigurationManager.ConnectionStrings["UserKateto"].ConnectionString;
        }
    }
}