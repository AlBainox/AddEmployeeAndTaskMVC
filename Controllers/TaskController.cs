using Aplikacja_ASP_MVC.Infrastructure.Interfaces;
using Aplikacja_ASP_MVC.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Aplikacja_ASP_MVC.Infrastructure.Models;
using System.Linq;
using System.Threading.Tasks;
using Aplikacja_ASP_MVC.Models;

namespace Aplikacja_ASP_MVC.Controllers
{
    public class TaskController : Controller
	{
		public TaskController(ITask taskService, ApplicationDbContext dbContext)
		{
			this.taskService= taskService;
			
		}
		private readonly ITask taskService;		

		public async Task<IActionResult> OpenAddingTask()
		{
			var taskViewModel = await taskService.OpenAddingTask();
			
			return View("OpenAddingTask", taskViewModel);
		}
		public async Task<IActionResult> SaveTask(TaskViewModel taskViewModel)
		{
			 await taskService.SaveTask(taskViewModel);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> SaveStatus(int taskid, string status)
		{
			await taskService.SaveStatus(taskid, status);	
			return Ok();
		}
	}
}
