using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebForms_ToDoTasks.Models;

namespace WebForms_ToDoTasks.DataAccess
{
    public class ToDoTasksRepository : IRepository<ToDoTask>
    {
        private ToDoTasksDbContext db;

        public ToDoTasksRepository()
        {
            db = new ToDoTasksDbContext();
        }

        public ToDoTask Add(ToDoTask entity)
        {
            InsertToDoTaskData(entity);
            return entity;
        }

        public IQueryable<ToDoTask> Get()
        {
            return ReadToDoTasksData();
        }

        public ToDoTask Get(int id)
        {
            return FindToDoTaskById(id);
        }

        public void Remove(int id)
        {
            DeleteToDoTaskData(id);
        }

        public void Remove(ToDoTask entity)
        {
            DeleteToDoTaskData(entity.Id);
        }

        public ToDoTask Update(ToDoTask entity)
        {
            ModifyToDoTaskData(entity);
            return entity;
        }

        #region todotask Search
        public IQueryable<ToDoTask> GetByDescription(string description)
        {
            return FindToDoTaskByDescription(description);
        }
        #endregion

        #region private methods
        private IQueryable<ToDoTask> ReadToDoTasksData()
        {
            IList<ToDoTask> toDoTasksDb = new List<ToDoTask>();
            string queryString = "SELECT * FROM Task";
            try
            {
                using (OracleConnection connection = new OracleConnection(db.connectionString))
                {
                    OracleCommand command = new OracleCommand(queryString, connection);
                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        // Always call Read before accessing data.
                        while (reader.Read())
                        {
                            toDoTasksDb.Add(new ToDoTask() { Id = reader.GetInt32(0), Name = reader.GetString(1), Description = reader.GetString(2), ToDoDate = reader.GetDateTime(3), Status = reader.GetString(4) == "0" ? false : true, CategoryId = reader.GetInt32(5) });
                            Debug.WriteLine(reader.GetInt32(0) + ", " + reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetDateTime(3) + ", " + reader.GetString(4) + ", " + reader.GetInt32(5));
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return new EnumerableQuery<ToDoTask>(toDoTasksDb);
        }

        private void InsertToDoTaskData(ToDoTask entity)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(db.connectionString))
                {
                    connection.Open();
                    OracleCommand insertCommand =
                        new OracleCommand("INSERT INTO Task (NAME, DESCRIPTION, TODODATE, STATUS, CATEGORYID) VALUES (:0, :1, :2, :3, :4)", connection);
                    insertCommand.Parameters.Add(new OracleParameter("0", entity.Name));
                    insertCommand.Parameters.Add(new OracleParameter("1", entity.Description));
                    insertCommand.Parameters.Add(new OracleParameter("2", entity.ToDoDate));
                    insertCommand.Parameters.Add(new OracleParameter("3", entity.Status == true ? '1' : '0'));
                    insertCommand.Parameters.Add(new OracleParameter("4", entity.CategoryId));
                    insertCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void DeleteToDoTaskData(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString())) return;
            try
            {
                using (OracleConnection connection = new OracleConnection(db.connectionString))
                {
                    connection.Open();
                    OracleCommand deleteCommand =
                        new OracleCommand(string.Format("DELETE FROM Task WHERE id = '{0}'", id), connection);
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void ModifyToDoTaskData(ToDoTask entity)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(db.connectionString))
                {
                    connection.Open();
                    OracleCommand updateCommand =
                        new OracleCommand("UPDATE Task set name = :0, description = :1, TODODATE = :2, status = :3, categoryid = :4 where id = :5", connection);
                    updateCommand.Parameters.Add(new OracleParameter("0", entity.Name));
                    updateCommand.Parameters.Add(new OracleParameter("1", entity.Description));
                    updateCommand.Parameters.Add(new OracleParameter("2", entity.ToDoDate));
                    updateCommand.Parameters.Add(new OracleParameter("3", entity.Status == true ? '1' : '0'));
                    updateCommand.Parameters.Add(new OracleParameter("4", entity.CategoryId));
                    updateCommand.Parameters.Add(new OracleParameter("5", entity.Id));
                    updateCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private ToDoTask FindToDoTaskById(int id)
        {
            IList<ToDoTask> toDoTasksDb = new List<ToDoTask>();
            string queryString = string.Format("SELECT * FROM Task where id={0}", id);
            try
            {
                using (OracleConnection connection = new OracleConnection(db.connectionString))
                {
                    OracleCommand command = new OracleCommand(queryString, connection);
                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        // Always call Read before accessing data.
                        while (reader.Read())
                        {
                            toDoTasksDb.Add(new ToDoTask() { Id = reader.GetInt32(0), Name = reader.GetString(1), Description = reader.GetString(2), ToDoDate = reader.GetDateTime(3), Status = reader.GetString(4) == "0" ? false : true, CategoryId = reader.GetInt32(5) });
                            Debug.WriteLine(reader.GetInt32(0) + ", " + reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetDateTime(3) + ", " + reader.GetString(4) + ", " + reader.GetInt32(5));
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return toDoTasksDb.FirstOrDefault();
        }

        private IQueryable<ToDoTask> FindToDoTaskByDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description)) return null;
            IList<ToDoTask> toDoTasksDb = new List<ToDoTask>();
            string queryString =(string.Format(@"SELECT * FROM Task where DESCRIPTION LIKE '%{0}%'", description));
            try
            {
                using (OracleConnection connection = new OracleConnection(db.connectionString))
                {
                    OracleCommand command = new OracleCommand(queryString, connection);
                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        // Always call Read before accessing data.
                        while (reader.Read())
                        {
                            toDoTasksDb.Add(new ToDoTask() { Id = reader.GetInt32(0), Name = reader.GetString(1), Description = reader.GetString(2), ToDoDate = reader.GetDateTime(3), Status = reader.GetString(4) == "0" ? false : true, CategoryId = reader.GetInt32(5) });
                            Debug.WriteLine(reader.GetInt32(0) + ", " + reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetDateTime(3) + ", " + reader.GetString(4) + ", " + reader.GetInt32(5));
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return new EnumerableQuery<ToDoTask>(toDoTasksDb);

        }
        #endregion

    }
}