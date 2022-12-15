using Aplikacja_ASP_MVC.Infrastructure.Interfaces;
using Aplikacja_ASP_MVC.Infrastructure.Models;
using Aplikacja_ASP_MVC.Infrastructure.ViewModel;
using Aplikacja_ASP_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacja_ASP_MVC.Controllers
{
	public class EmployeeController : Controller
	{
		public EmployeeController(IEmployee employeeService)
		{
			this.employeeService = employeeService;			
		}
		private readonly IEmployee employeeService;
		
		public async Task<IActionResult> OpenAddingEmployee()
		{
			var EmployeeViewModel = employeeService.OpenAddingEmployee();
			return View("OpenAddingEmployee", await EmployeeViewModel);
		}
		public async Task<IActionResult> SaveEmployee(EmployeeViewModel evm)
		{
			await employeeService.SaveEmployee(evm);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> RemoveEmployee(int id)
		{
			await employeeService.RemoveEmployee(id);
			return NoContent();
		}
	}
}
