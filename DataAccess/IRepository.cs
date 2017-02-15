using System.Linq;
using TDTModels;

namespace DataAccess
{
    public interface IRepository<T>
     where T : class, IIdentifiableEntity
    {
        T Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        T Update(T entity);
        IQueryable<T> Get();
        T Get(int id);
    }
}
