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

        public IQueryable<ToDoTask> Get()
        {
            return dataDb.Get();
        }

        public void UpdateToDoTask(ToDoTask entity)
        {
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

        public IQueryable<ToDoTask> FindToDoTasksByDescription(string description)
        {
            if (dataDb is ToDoTasksRepository)
            {
                return (dataDb as ToDoTasksRepository).GetByDescription(description);
            }
            else return null;
        }

        public IQueryable<ToDoTask> FindToDoTasksByDate(string date)
        {
            if (dataDb is ToDoTasksRepository)
            {
                return (dataDb as ToDoTasksRepository).GetByDate(date);
            }
            else return null;
        }
    }
}
