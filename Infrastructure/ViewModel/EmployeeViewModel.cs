using Aplikacja_ASP_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacja_ASP_MVC.Infrastructure.ViewModel
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Pole imię jest wymagane")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pole nazwisko jest wymagane")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Pole email jest wymagane")]
        [EmailAddress(ErrorMessage = "Błędny adres email")]
        public string Email { get; set; }
        [Required]
        public List<string> Position { get; set; }
        public List<TaskViewModel> Tasks { get; set; }
    }
}
