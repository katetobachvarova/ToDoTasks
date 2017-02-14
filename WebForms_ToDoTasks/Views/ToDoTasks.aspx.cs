using DataAccess;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms_ToDoTasks.Controllers;
using WebForms_ToDoTasks.DataAccess;
using WebForms_ToDoTasks.Models;
using Resources;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebForms_ToDoTasks.Views
{
    public partial class ToDoTasks : System.Web.UI.Page
    {
        private IToDoTaskRepository repo;
        private ToDoTasksController taskController;
        private HttpClient client;

        protected  void Page_Load(object sender, EventArgs e)
        {
            DbContext db = new DbContext(ConfigurationManager.ConnectionStrings["UserKateto"].ConnectionString);
            //DbContext db = new DbContext(Resources.ResourceWebApp.connectionStringOracleToDoTasksDb);

            repo = new ToDoTasksRepository(db);
            taskController = new ToDoTasksController(repo);
            t1.DateFormat = "dd/mm/yy";
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55404/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }


        // The id parameter name should match the DataKeyNames value set on the control
        public async Task<HttpStatusCode> gvToDoTasks_UpdateItem(int id)
        {
            var item = new WebForms_ToDoTasks.Models.ToDoTask();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                //taskController.UpdateToDoTask(item);
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/tdt/{item.Id}", item);
                return response.StatusCode;
            }
            return HttpStatusCode.BadRequest;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public async void gvToDoTasks_DeleteItem(int id)
        {
            // taskController.DeleteToDoTask(id);
            await client.DeleteAsync($"api/tdt/{id}");
        }

        public  async IQueryable<WebForms_ToDoTasks.Models.ToDoTask> gvToDoTasks_GetData()
        //public IQueryable<WebForms_ToDoTasks.Models.ToDoTask> gvToDoTasks_GetData()

        {
            if (!string.IsNullOrEmpty(SerchByDescriptionTextBox.Text) && !string.IsNullOrEmpty(SearchByDateTextBox.Text))
            {
                IQueryable<ToDoTask> toDoTasks = taskController.FindToDoTasksByDateAndDescription(SearchByDateTextBox.Text, SerchByDescriptionTextBox.Text);
                return toDoTasks;
            }
            else if (!string.IsNullOrEmpty(SerchByDescriptionTextBox.Text))
            {
                string t = SerchByDescriptionTextBox.Text;
                IQueryable<ToDoTask> toDoTasks = taskController.FindToDoTasksByDescription(t);
                return toDoTasks;
            }
            else if (!string.IsNullOrEmpty(SearchByDateTextBox.Text))
            {
                string t = SearchByDateTextBox.Text;
                IQueryable<ToDoTask> toDoTasks = taskController.FindToDoTasksByDate(t);
                return toDoTasks;
            }
            else
            {
                //IQueryable<ToDoTask> toDoTasks = taskController.Get();
                //return toDoTasks;
                ToDoTask[] allT = await GetAllTasks();
                IQueryable<ToDoTask> allTasks = allT.AsQueryable();
                return allTasks;
            }

        }

        private async Task<ToDoTask[]> GetAllTasks()
        {
            ToDoTask[] toDoTasks = null;
            HttpResponseMessage response = await client.GetAsync("api/tdt");
            //Response.ContentType = "application/json";
            if (response.IsSuccessStatusCode)
            {
                var msg = response.Content.ReadAsStringAsync().Result;
                toDoTasks = response.Content.ReadAsAsync<ToDoTask[]>().Result;
                //toDoTasks = JsonConvert.DeserializeObject<ToDoTask[]>(msg);

            }
            return toDoTasks;
        }

        protected void gvToDoTasks_DataBound(object sender, EventArgs e)
        {
            lblNoResultMessage.Visible = (gvToDoTasks.Rows.Count == 0);

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvToDoTasks.DataBind();
        }

        protected void gvToDoTasks_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            gvToDoTasks.DataBind();
        }

        protected void gvToDoTasks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // if enter key is pressed (keycode==13) call __doPostBack on grid and with
            // 1st param = gvChild.UniqueID (Gridviews UniqueID)
            // 2nd param = CommandName=Update$  +  CommandArgument=RowIndex
            if ((e.Row.RowState == (DataControlRowState.Edit)) ||
               (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)))
            {
                e.Row.Attributes.Add("onkeypress", "javascript:if (event.keyCode == 13) { __doPostBack('" + gvToDoTasks + "', 'Update$" + e.Row.RowIndex.ToString() + "'); return false; }");
                //javascript: WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$MainContent$gvToDoTasks$ctl02$ctl00", "", true, "", "", false, true))
            }
        }


        async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/tdt/{id}");
            return response.StatusCode;
        }

        protected async void TestDeleteClick(object sender, EventArgs e)
        {
             await DeleteProductAsync("68");
        }

        protected async void TestUpdateClick(object sender, EventArgs e)
        {
            ToDoTask taskToUpdate = repo.Get(81);
            taskToUpdate.Description = "бг web api test";
            await UpdateProductAsync(taskToUpdate);
        }
        async Task<HttpStatusCode> UpdateProductAsync(ToDoTask product)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/tdt/{product.Id}", product);
            return response.StatusCode;
        }

        protected async void TestCreateClick(object sender, EventArgs e)
        {
            //ToDoTask newtask = new ToDoTask() { Name = "тест", Description = "test again web api", CategoryId = 2, Status = true, ToDoDate = DateTime.Now };
            //await CreateProductAsync(newtask);
            var allTasks = await GetAllTasks();
        }
        async Task<HttpStatusCode> CreateProductAsync(ToDoTask task)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/tdt", task);
            return response.StatusCode;
        }
    }
}