using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms_ToDoTasks.Controllers;
using WebForms_ToDoTasks.DataAccess;
using WebForms_ToDoTasks.Models;

namespace WebForms_ToDoTasks.Views
{
    public partial class ToDoTasks : System.Web.UI.Page
    {
        private IRepository<ToDoTask> repo;

        protected void Page_Load(object sender, EventArgs e)
        {
            repo = new ToDoTasksRepository();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridView1_UpdateItem(int id)
        {
            //ToDoTasksController taskController = new ToDoTasksController(repo);
            //taskController.UpdateToDoTask(id);

            var item = new WebForms_ToDoTasks.Models.ToDoTask();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                ToDoTasksController taskController = new ToDoTasksController(repo);
                taskController.UpdateToDoTask(item);

                // Save changes here

            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridView1_DeleteItem(int id)
        {
            ToDoTasksController taskController = new ToDoTasksController(repo);
            taskController.DeleteToDoTask(id);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        //public IEnumerable<WebForms_ToDoTasks.Models.ToDoTask> GridView1_GetData(int maximumRows, int startRowIndex, out int totalRowCount, string sortByExpression)
        public IQueryable<WebForms_ToDoTasks.Models.ToDoTask> GridView1_GetData()
        {
            ToDoTasksController taskController = new ToDoTasksController(repo);
            IQueryable<ToDoTask> toDoTasks = taskController.Get();
            //totalRowCount = toDoTasks.ToList().Count;
            return toDoTasks;
        }
    }
}