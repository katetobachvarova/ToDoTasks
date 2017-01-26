using DataAccess;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using WebForms_ToDoTasks.Models;

namespace WebForms_ToDoTasks.DataAccess
{
    public class ToDoTasksRepository : RepositoryBase<ToDoTask>, IToDoTaskRepository
    {
        public ToDoTasksRepository(DbContext db)
        {
            //db = new DbContext(ConfigurationManager.ConnectionStrings["UserKateto"].ConnectionString);
            this.db = db;
        }

        public override ToDoTask Add(ToDoTask entity)
        {
            InsertToDoTaskData(entity);
            return entity;
        }

        public override IQueryable<ToDoTask> Get()
        {
            return ReadToDoTasksData();
        }

        public override ToDoTask Get(int id)
        {
            return FindToDoTaskById(id);
        }

        public override void Remove(int id)
        {
            DeleteToDoTaskData(id);
        }

        public override void Remove(ToDoTask entity)
        {
            DeleteToDoTaskData(entity.Id);
        }

        public override ToDoTask Update(ToDoTask entity)
        {
            ModifyToDoTaskData(entity);
            return entity;
        }

        #region todotask specific Search
        public IQueryable<ToDoTask> GetByDescription(string description)
        {
            return FindToDoTaskByDescription(description);
        }
        public IQueryable<ToDoTask> GetByDate(string date)
        {
            return FindToDoTaskByDate(date);
        }
        #endregion

        #region private methods
        private void InsertToDoTaskData(ToDoTask entity)
        {
            OracleParameter[] oracleParams = new OracleParameter[] 
            {
                new OracleParameter("0", entity.Name),
                new OracleParameter("1", entity.Description),
                new OracleParameter("2", entity.ToDoDate),
                new OracleParameter("3", entity.Status == true ? '1' : '0'),
                new OracleParameter("4", entity.CategoryId)
            };
            ExecuteCommand(db.connectionString, "INSERT INTO Task (NAME, DESCRIPTION, TODODATE, STATUS, CATEGORYID) VALUES (:0, :1, :2, :3, :4)", oracleParams);
        }

       
        private void DeleteToDoTaskData(int id)
        {
            ExecuteCommand(db.connectionString, string.Format("DELETE FROM Task WHERE id = '{0}'", id), new OracleParameter[] { });
        }

        private void ModifyToDoTaskData(ToDoTask entity)
        {
            OracleParameter[] oracleParams = new OracleParameter[]
            {
                new OracleParameter("0", entity.Name),
                new OracleParameter("1", entity.Description),
                new OracleParameter("2", entity.ToDoDate),
                new OracleParameter("3", entity.Status == true ? '1' : '0'),
                new OracleParameter("4", entity.CategoryId),
                new OracleParameter("5", entity.Id)
            };
            ExecuteCommand(db.connectionString, "UPDATE Task set name = :0, description = :1, TODODATE = :2, status = :3, categoryid = :4 where id = :5", oracleParams);
        }

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
                        while (reader.Read())
                        {
                            toDoTasksDb.Add(new ToDoTask() { Id = reader.GetInt32(0), Name = reader.GetString(1), Description = reader.GetString(2), ToDoDate = reader.GetDateTime(3), Status = reader.GetString(4) == "0" ? false : true, CategoryId = reader.GetInt32(5) });
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

        //private IQueryable<ToDoTask> FindToDoTaskByDate(string date)
        //{
        //    if (string.IsNullOrWhiteSpace(date)) return null;
        //    IList<ToDoTask> toDoTasksDb = new List<ToDoTask>();
        //    OracleParameter[] oracleParams = new OracleParameter[]
        //    {
        //        new OracleParameter("0", date)
        //    };
        //    string queryString = (string.Format(@"SELECT * FROM Task where tododate = TO_DATE('{0}', 'dd/MM/yyyy')", date));
        //    try
        //    {
        //        using (OracleConnection connection = new OracleConnection(db.connectionString))
        //        {
        //            OracleCommand command = new OracleCommand(queryString, connection);
        //            connection.Open();
        //            using (OracleDataReader reader = command.ExecuteReader())
        //            {
        //                // Always call Read before accessing data.
        //                while (reader.Read())
        //                {
        //                    toDoTasksDb.Add(new ToDoTask() { Id = reader.GetInt32(0), Name = reader.GetString(1), Description = reader.GetString(2), ToDoDate = reader.GetDateTime(3), Status = reader.GetString(4) == "0" ? false : true, CategoryId = reader.GetInt32(5) });
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //    return new EnumerableQuery<ToDoTask>(toDoTasksDb);

        //}

        private IQueryable<ToDoTask> FindToDoTaskByDate(string date)
        {
            if (string.IsNullOrWhiteSpace(date)) return null;
            IList<ToDoTask> toDoTasksDb = new List<ToDoTask>();
            DateTime validatedDate;
            string[] formats = new string[] { "dd/MM/yyyy"}; 
            var dateTime = DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out validatedDate);
            if (dateTime)
            {

            
            OracleParameter[] oracleParams = new OracleParameter[]
            {
                new OracleParameter("0", validatedDate.ToShortDateString())
            };
                string queryString = "SELECT * FROM Task where tododate = TO_DATE( :0, 'dd/mm/yyyy')";
                //string queryString = "SELECT * FROM Task where tododate = validatedDate";
               // string queryString = "SELECT * FROM Task where tododate = TO_DATE( :0)";
                try
                {
                using (OracleConnection connection = new OracleConnection(db.connectionString))
                {
                    OracleCommand command = new OracleCommand(queryString, connection);
                    command.Parameters.AddRange(oracleParams);
                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        // Always call Read before accessing data.
                        while (reader.Read())
                        {
                            toDoTasksDb.Add(new ToDoTask() { Id = reader.GetInt32(0), Name = reader.GetString(1), Description = reader.GetString(2), ToDoDate = reader.GetDateTime(3), Status = reader.GetString(4) == "0" ? false : true, CategoryId = reader.GetInt32(5) });
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
            else
            {
                return null;
            }
        }
        #endregion

    }
}