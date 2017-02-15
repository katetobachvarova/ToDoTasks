using DataAccess;
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
        private IToDoTaskRepository dataDb;

        public ToDoTasksController(IToDoTaskRepository repository)
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
            return dataDb.GetByDescription(description);
        }

        public IQueryable<ToDoTask> FindToDoTasksByDate(string date)
        {
            return dataDb.GetByDate(date);
        }

        public IQueryable<ToDoTask> FindToDoTasksByDateAndDescription(string date, string description)
        {
            return dataDb.GetByDateAndDescription(date, description);
        }

       

    }
}
