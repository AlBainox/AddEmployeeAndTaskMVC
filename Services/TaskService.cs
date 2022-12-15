using Aplikacja_ASP_MVC.Infrastructure.Interfaces;
using Aplikacja_ASP_MVC.Infrastructure.ViewModel;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aplikacja_ASP_MVC.Infrastructure.Models;
using System.Linq;
using Aplikacja_ASP_MVC.Models;

namespace Aplikacja_ASP_MVC.Services
{
    public class TaskService : ITask		
	{
		public TaskService(ApplicationDbContext dbContext)
		{
			this.DbContext = dbContext;
		}

		private readonly ApplicationDbContext DbContext;

		public async Task<TaskViewModel> OpenAddingTask()
		{
			var tvm = new TaskViewModel();
			tvm.Status = new List<string>()
			{
				new string("NEW"),
				new string("IN PROGRESS"),
				new string("TO SPECIFY"),
				new string("REOPENED"),
				new string("TO TEST"),
				new string("COMPLETED"),
				new string("CANCELED"),
			};

			tvm.EmployeesSelectList = new List<SelectListItem>();

			foreach (var employee in DbContext.Employees)
			{
				tvm.EmployeesSelectList.Add(new SelectListItem
				{
					Text = $"{employee.Name} {employee.Surname} [ {employee.Position} ]",
					Value = employee.ID.ToString(),
				});
			}

			tvm.Deadline = DateTime.Now;

			return await Task.FromResult(tvm);
		}

		public async Task SaveTask(TaskViewModel taskViewModel)
		{
			var numberOfId = int.Parse(taskViewModel.SelectedEmployee);
			var employee = DbContext.Employees.Where(e => e.ID == numberOfId).FirstOrDefault();

			var newTask = new TaskToWork()
			{
				Title = taskViewModel.Title,
				Description = taskViewModel.Description,
				Deadline = taskViewModel.Deadline,
				Status = taskViewModel.Status.FirstOrDefault(),
				Employee = employee,
			};
			DbContext.Tasks.Add(newTask);
			await DbContext.SaveChangesAsync();
		}

		public async Task SaveStatus(int taskid, string status)
		{
			var taskToChange = DbContext.Tasks.Where(w => w.Id == taskid).FirstOrDefault();
			taskToChange.Status = status;
			DbContext.Entry(taskToChange);
			await DbContext.SaveChangesAsync();
		}
	}
}
