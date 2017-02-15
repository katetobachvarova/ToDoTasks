using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms_ToDoTasks.Controllers;
using WebForms_ToDoTasks.DataAccess;
using WebForms_ToDoTasks.Models;

namespace WebForms_ToDoTasks.Views
{
    public partial class ToDoTaskAdd : System.Web.UI.Page
    {
        private IToDoTaskRepository repo;
        private HttpClient client;
        private WebClient webClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            DbContext db = new DbContext(ConfigurationManager.ConnectionStrings["UserKateto"].ConnectionString);
            //DbContext db = new DbContext(Resources.ResourceWebApp.connectionStringOracleToDoTasksDb);
            repo = new ToDoTasksRepository(db);
            client = new HttpClient();
            webClient = new WebClient();
            client.BaseAddress = new Uri("http://localhost:55404/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public string addToDoTaskForm_InsertItem()
        {
            // Create string to hold JSON response
            string jsonResponse = string.Empty;
            var item = new WebForms_ToDoTasks.Models.ToDoTask();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                using (webClient)
                {
                    var dataString = JsonConvert.SerializeObject(item);
                    webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    var response = webClient.UploadString(new Uri("http://localhost:55404/api/tdt"), "POST", dataString);
                    jsonResponse = response;
                }
            }
            return jsonResponse;
        }

        //Async version
        //public async Task<HttpStatusCode> addToDoTaskForm_InsertItem()
        //{
        //    var item = new WebForms_ToDoTasks.Models.ToDoTask();
        //    TryUpdateModel(item);
        //    if (ModelState.IsValid)
        //    {
        //        //ToDoTasksController taskController = new ToDoTasksController(repo);
        //        ///taskController.AddToDoTask(item);
        //        HttpResponseMessage response = await client.PostAsJsonAsync("api/tdt", item);
        //        return response.StatusCode;

        //    }
        //    return HttpStatusCode.BadRequest;
        //}

        protected void addToDoTaskForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("~/Views/ToDoTasks.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ToDoTasks.aspx");
        }
    }
}