using System.Linq;
using TDTModels;

namespace DataAccess
{
    public interface IToDoTaskRepository : IRepository<ToDoTask>
    {
        IQueryable<ToDoTask> GetByDescription(string description);
        IQueryable<ToDoTask> GetByDate(string date);
        IQueryable<ToDoTask> GetByDateAndDescription(string date, string description);

    }
}
