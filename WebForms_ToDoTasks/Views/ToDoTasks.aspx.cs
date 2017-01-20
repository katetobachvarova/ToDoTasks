using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms_ToDoTasks.Controllers;

namespace WebForms_ToDoTasks.Views
{
    public partial class ToDoTasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ToDoTasksController taskController = new ToDoTasksController();
            //taskController.Create();
            Response.Redirect("ToDoTaskAdd.aspx");

            //using (OracleConnection connection = new OracleConnection(
            //        "DATA SOURCE=localhost:1521/XE;PASSWORD=123;PERSIST SECURITY INFO=True;USER ID=KATETO"))
            //{
            //    connection.Open();
            //    OracleCommand insertCommand =
            //        new OracleCommand("INSERT INTO Task (id, NAME, description, categoryid, status, TODODATE) VALUES (:0, :1, :2, :3, :4, :5)", connection);
            //    insertCommand.Parameters.Add(new OracleParameter("0", 5));
            //    insertCommand.Parameters.Add(new OracleParameter("1", "kat"));
            //    insertCommand.Parameters.Add(new OracleParameter("2", " more test from VS"));
            //    insertCommand.Parameters.Add(new OracleParameter("3", 1));
            //    insertCommand.Parameters.Add(new OracleParameter("4", "0"));
            //    insertCommand.Parameters.Add(new OracleParameter("5", DateTime.Now));
            //    insertCommand.ExecuteNonQuery();
            //    connection.Close();

            //}

            //SqlCommand command = new SqlCommand("SELECT * FROM TableName WHERE FirstColumn = @0", conn);

        }
    }
}