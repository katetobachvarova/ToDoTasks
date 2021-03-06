﻿using DataAccess;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms_ToDoTasks.Controllers;
using WebForms_ToDoTasks.DataAccess;
using WebForms_ToDoTasks.Models;
using Resources;

namespace WebForms_ToDoTasks.Views
{
    public partial class ToDoTasks : System.Web.UI.Page
    {
        private IToDoTaskRepository repo;
        private ToDoTasksController taskController;

        protected void Page_Load(object sender, EventArgs e)
        {
            DbContext db = new DbContext(ConfigurationManager.ConnectionStrings["UserKateto"].ConnectionString);
            //DbContext db = new DbContext(Resources.ResourceWebApp.connectionStringOracleToDoTasksDb);

            repo = new ToDoTasksRepository(db);
            taskController = new ToDoTasksController(repo);
            t1.DateFormat = "dd/mm/yy";
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gvToDoTasks_UpdateItem(int id)
        {
            var item = new WebForms_ToDoTasks.Models.ToDoTask();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                taskController.UpdateToDoTask(item);
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void gvToDoTasks_DeleteItem(int id)
        {
            taskController.DeleteToDoTask(id);
        }

        public IQueryable<WebForms_ToDoTasks.Models.ToDoTask> gvToDoTasks_GetData()

        {
            if (!string.IsNullOrEmpty(SerchByDescriptionTextBox.Text) && !string.IsNullOrEmpty(SearchByDateTextBox.Text))
            {
                IQueryable<ToDoTask> toDoTasks = taskController.FindToDoTasksByDateAndDescription(SearchByDateTextBox.Text, SerchByDescriptionTextBox.Text);
                return toDoTasks;
            }
            else if (!string.IsNullOrEmpty(SerchByDescriptionTextBox.Text))
            {
                string t = SerchByDescriptionTextBox.Text;
                IQueryable<ToDoTask> toDoTasks = taskController.FindToDoTasksByDescription(t);
                return toDoTasks;
            }
            else if (!string.IsNullOrEmpty(SearchByDateTextBox.Text))
            {
                string t = SearchByDateTextBox.Text;
                IQueryable<ToDoTask> toDoTasks = taskController.FindToDoTasksByDate(t);
                return toDoTasks;
            }
            else
            {
                IQueryable<ToDoTask> toDoTasks = taskController.Get();
                return toDoTasks;
            }

        }

        protected void gvToDoTasks_DataBound(object sender, EventArgs e)
        {
            lblNoResultMessage.Visible = (gvToDoTasks.Rows.Count == 0);

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvToDoTasks.DataBind();
        }

        protected void gvToDoTasks_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            gvToDoTasks.DataBind();
        }

        protected void gvToDoTasks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // if enter key is pressed (keycode==13) call __doPostBack on grid and with
            // 1st param = gvChild.UniqueID (Gridviews UniqueID)
            // 2nd param = CommandName=Update$  +  CommandArgument=RowIndex
            if ((e.Row.RowState == (DataControlRowState.Edit)) ||
               (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)))
            {
                e.Row.Attributes.Add("onkeypress", "javascript:if (event.keyCode == 13) { __doPostBack('" + gvToDoTasks + "', 'Update$" + e.Row.RowIndex.ToString() + "'); return false; }");
                //javascript: WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$MainContent$gvToDoTasks$ctl02$ctl00", "", true, "", "", false, true))
            }
        }

    }
}