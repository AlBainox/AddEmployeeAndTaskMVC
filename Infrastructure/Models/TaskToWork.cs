using System.Collections.Generic;
using System;

namespace Aplikacja_ASP_MVC.Infrastructure.Models
{
    public class TaskToWork
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public Employee Employee { get; set; }
    }
}
