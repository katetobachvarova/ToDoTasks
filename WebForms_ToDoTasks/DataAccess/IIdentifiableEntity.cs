using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms_ToDoTasks.DataAccess
{
    public interface IIdentifiableEntity
    {
        int Id { get; set; }
    }
}