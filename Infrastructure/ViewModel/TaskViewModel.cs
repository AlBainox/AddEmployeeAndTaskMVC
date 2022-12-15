using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aplikacja_ASP_MVC.Infrastructure.ViewModel
{
    public class TaskViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Title { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Description { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane")]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; }
        public List<string> Status { get; set; }

        public List<SelectListItem> EmployeesSelectList { get; set; }
        public string SelectedEmployee { get; set; }

    }
}
