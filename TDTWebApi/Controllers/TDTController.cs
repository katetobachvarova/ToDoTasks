using DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebForms_ToDoTasks.DataAccess;
using WebForms_ToDoTasks.Models;

namespace TDTWebApi.Controllers
{
    public class TDTController : ApiController
    {
        private IToDoTaskRepository dataDb;

        public TDTController(IToDoTaskRepository repository)
        {
            dataDb = repository;
        }

        public TDTController()
        {
           // dataDb =
            DbContext db = new DbContext(ConfigurationManager.ConnectionStrings["UserKateto"].ConnectionString);
            //DbContext db = new DbContext(Resources.ResourceWebApp.connectionStringOracleToDoTasksDb);

            dataDb = new ToDoTasksRepository(db);
            //taskController = new ToDoTasksController(repo);
        }

        // GET: api/TDT
        public IEnumerable<ToDoTask> Get()
        {
            return dataDb.Get().ToArray();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/TDT/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TDT
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TDT/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TDT/5
        public void Delete(int id)
        {
        }
    }
}
