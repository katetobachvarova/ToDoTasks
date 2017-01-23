using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebForms_ToDoTasks.DataAccess
{
    public interface IRepository<T>
     where T : class, IIdentifiableEntity
    {
        T Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        T Update(T entity);
        IEnumerable<T> Get();
        T Get(int id);
    }
}
