using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebForms_ToDoTasks.Models;

namespace ToDoTasksWebApi.Controllers
{
    public class TasksController : ApiController
    {
        private ToDoTask[] tasks = new ToDoTask[]
        {
            new ToDoTask { Name ="kat", Description="test from api"},
            new ToDoTask { Name = "bla", Description="another one "}
        };

        // GET: api/Tasks
        public IEnumerable<ToDoTask> Get()
        {
            return tasks;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Tasks/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tasks
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tasks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tasks/5
        public void Delete(int id)
        {
        }
    }
}
