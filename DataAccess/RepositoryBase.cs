using Oracle.ManagedDataAccess.Client;
using System;
using System.Linq;
using TDTModels;

namespace DataAccess
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, IIdentifiableEntity
    {
        protected DbContext db;

        public abstract T Add(T entity);

        public abstract IQueryable<T> Get();

        public abstract T Get(int id);

        public abstract void Remove(int id);

        public abstract void Remove(T entity);

        public abstract T Update(T entity);

        public void ExecuteCommand(string connStr, string queryStr, params OracleParameter[] oracleParams)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connStr))
                {
                    connection.Open();
                    OracleCommand command =
                        new OracleCommand(queryStr, connection);
                    foreach (var item in oracleParams)
                    {
                        command.Parameters.Add(item);
                    }
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
