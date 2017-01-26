using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebForms_ToDoTasks.DataAccess;

namespace WebForms_ToDoTasks.Models
{
    public class ToDoTask : IIdentifiableEntity
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Range(typeof(DateTime), "1/1/1900", "1/1/2100", ErrorMessage = "Please provide date after 1/1/1900 and before 1/1/2100 ")]
        //[DisplayFormat(ApplyFormatInEditMode = true)]
         //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ToDoDate { get; set; }

        [Display(Name = "Completed")]
        public bool Status { get; set; }

        [EnumDataType(typeof(Category)), Display(Name = "Category")]
        public int CategoryId { get; set; }
    }

    public enum Category
    {
        Work = 1,
        Home = 2,
        Family = 3
    }
}