using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForms_ToDoTasks.Models;

namespace WebForms_ToDoTasks.DataAccess
{
    public interface IToDoTaskRepository : IRepository<ToDoTask>
    {
        IQueryable<ToDoTask> GetByDescription(string description);
        IQueryable<ToDoTask> GetByDate(string date);
    }
}
