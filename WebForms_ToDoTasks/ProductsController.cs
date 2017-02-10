using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using WebForms_ToDoTasks.DataAccess;
using WebForms_ToDoTasks.Models;

namespace WebForms_ToDoTasks
{
    public class ProductsController : ApiController
    {
        private IToDoTaskRepository dataDb;

        private ToDoTask[] products; 

        public ProductsController(IToDoTaskRepository repository)
        {
            dataDb = repository;
            //products = Get().ToArray();
        }


        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}