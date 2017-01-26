using DataAccess;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
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
        private IToDoTaskRepository repo;

        protected void Page_Load(object sender, EventArgs e)
        {
            DbContext db = new DbContext(ConfigurationManager.ConnectionStrings["UserKateto"].ConnectionString);
            repo = new ToDoTasksRepository(db);
            t1.DateFormat = "dd/mm/yy"; ;
            //if (!IsPostBack)
            //{
            //    Response.Write("Loaded for first time");
            //}
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
        //public IQueryable<WebForms_ToDoTasks.Models.ToDoTask> GridView1_GetData()
        //{
        //    if (string.IsNullOrEmpty(SerchByDescriptionTextBox.Text) && string.IsNullOrEmpty(SearchByDateTextBox.Text))
        //    {
        //        ToDoTasksController taskController = new ToDoTasksController(repo);
        //        IQueryable<ToDoTask> toDoTasks = taskController.Get();
        //        return toDoTasks;
        //    }
        //    else if (!string.IsNullOrEmpty(SerchByDescriptionTextBox.Text))
        //    {
        //        string t = SerchByDescriptionTextBox.Text;
        //        ToDoTasksController taskController = new ToDoTasksController(repo);
        //        IQueryable<ToDoTask> toDoTasks = taskController.FindToDoTasksByDescription(t);
        //        return toDoTasks;
        //    }
        //    else if(!string.IsNullOrEmpty(SearchByDateTextBox.Text))
        //    {
        //        string t = SearchByDateTextBox.Text;
        //        ToDoTasksController taskController = new ToDoTasksController(repo);
        //        IQueryable<ToDoTask> toDoTasks = taskController.FindToDoTasksByDate(t);
        //        return toDoTasks;
        //    }
        //    else
        //    {
        //        return null;
        //    }
            
        //}

        public IQueryable<WebForms_ToDoTasks.Models.ToDoTask> GridView1_GetData()
        {
            if (!string.IsNullOrEmpty(SerchByDescriptionTextBox.Text) && !string.IsNullOrEmpty(SearchByDateTextBox.Text))
            {
                ToDoTasksController taskController = new ToDoTasksController(repo);
                IQueryable<ToDoTask> toDoTasks = taskController.FindToDoTasksByDateAndDescription(SearchByDateTextBox.Text, SerchByDescriptionTextBox.Text);
                return toDoTasks;
            }
            else if (!string.IsNullOrEmpty(SerchByDescriptionTextBox.Text) && !string.IsNullOrWhiteSpace(SerchByDescriptionTextBox.Text))
            {
                string t = SerchByDescriptionTextBox.Text;
                ToDoTasksController taskController = new ToDoTasksController(repo);
                IQueryable<ToDoTask> toDoTasks = taskController.FindToDoTasksByDescription(t);
                return toDoTasks;
            }
            else if (!string.IsNullOrEmpty(SearchByDateTextBox.Text) && !string.IsNullOrWhiteSpace(SearchByDateTextBox.Text))
            {
                string t = SearchByDateTextBox.Text;
                ToDoTasksController taskController = new ToDoTasksController(repo);
                IQueryable<ToDoTask> toDoTasks = taskController.FindToDoTasksByDate(t);
                return toDoTasks;
            }
            else
            {
                ToDoTasksController taskController = new ToDoTasksController(repo);
                IQueryable<ToDoTask> toDoTasks = taskController.Get();
                return toDoTasks;
            }

        }

        protected void SearchByDescription_Click(object sender, EventArgs e)
        {
            //string t = SerchByDescriptionTextBox.Text;
            //ToDoTasksController taskController = new ToDoTasksController(repo);
            //IQueryable<ToDoTask> toDoTasks = taskController.FindToDoTasksByDescription(t);
            SearchByDateTextBox.Text = "";
            GridView1.DataBind();
        }

        protected void SearchByDate_Click(object sender, EventArgs e)
        {
            SerchByDescriptionTextBox.Text = "";
            string date = SearchByDateTextBox.Text;
            DateTime validatedDate;
            string[] formats = new string[] { "dd/MM/yyyy" };
            var dateTime = DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out validatedDate);
            if (dateTime)
            {
                GridView1.DataBind();
            }
            else
            {
             
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            lblNoResultMessage.Visible = (GridView1.Rows.Count == 0);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
                GridView1.DataBind();
        }
    }
}