using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebForms_ToDoTasks.DataAccess;
using WebForms_ToDoTasks.Models;

namespace WebForms_ToDoTasks.Controllers
{
    public class ToDoTasksController 
    {
       private IRepository<ToDoTask> dataDb;

        public ToDoTasksController(IRepository<ToDoTask> repository)
        {
            dataDb = repository;
        }

        public IEnumerable<ToDoTask> Get()
        {
            return dataDb.Get();
        }

        public void UpdateToDoTask(ToDoTask entity)
        {
            //ToDoTask entityToUpdate = dataDb.Get(id);
            dataDb.Update(entity);
        }


        public void DeleteToDoTask(int id)
        {
            dataDb.Remove(id);
        }

        public void AddToDoTask(ToDoTask entity)
        {
            dataDb.Add(entity);
        }
    }
}
