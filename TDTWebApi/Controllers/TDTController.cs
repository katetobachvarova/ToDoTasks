using DataAccess;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using WebForms_ToDoTasks.DataAccess;
using WebForms_ToDoTasks.Models;

namespace TDTWebApi.Controllers
{
    [EnableCors(origins: "http://localhost:51721", headers: "*", methods: "*")]
    public class TDTController : ApiController
    {
        private IToDoTaskRepository dataDb;

        public TDTController(IToDoTaskRepository repository)
        {
            dataDb = repository;
        }

        public TDTController()
        {
            DbContext db = new DbContext(ConfigurationManager.ConnectionStrings["UserKateto"].ConnectionString);
            dataDb = new ToDoTasksRepository(db);
        }

        // GET: api/TDT
        public IEnumerable<ToDoTask> Get()
        {
            return dataDb.Get().ToArray();
        }

        // GET: api/TDT/5 http://localhost:55404/api/tdt/67
        public ToDoTask Get(int id)
        {
            return dataDb.Get(id);

        }

        // POST: api/TDT
        public void Post([FromBody]JObject valueName)
        {
            ToDoTask taskToAdd = Newtonsoft.Json.JsonConvert.DeserializeObject<ToDoTask>(valueName.ToString());
            dataDb.Add(taskToAdd);
        }

        // PUT: api/TDT/5
        public void Put(int id, [FromBody]JObject valueName)
        {
            ToDoTask taskToUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<ToDoTask>(valueName.ToString());
            dataDb.Update(taskToUpdate);
        }

        // DELETE: api/TDT/5 
        [WebInvoke(Method = "Delete", ResponseFormat = WebMessageFormat.Json)]
        public void Delete(int id)
        {
            dataDb.Remove(id);
        }
    }
}
