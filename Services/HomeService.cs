using Aplikacja_ASP_MVC.Infrastructure.Interfaces;
using Aplikacja_ASP_MVC.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aplikacja_ASP_MVC.Models;

namespace Aplikacja_ASP_MVC.Services
{
    public class HomeService : IHome
	{
		public HomeService(ApplicationDbContext dbContext)
		{ 
			this.DbContext = dbContext;
		}

		private readonly ApplicationDbContext DbContext;

		public async Task<EmployeesListViewModel> Index()
		{
			
			var employeesListViewModel = new EmployeesListViewModel();
			employeesListViewModel.EmployeesList = new List<EmployeeViewModel>();
			var employees = await DbContext.Employees.Include(e => e.Tasks).ToListAsync();

			foreach (var employee in employees)
			{
				List<string> positionList = new List<string>();
				positionList.Add(employee.Position);
				List<TaskViewModel> tasksLVM = new List<TaskViewModel>();

				foreach (var task in employee.Tasks)
				{
					var singleStatus = new List<string>
					{
						new string(task.Status)
					};
					tasksLVM.Add(new TaskViewModel
					{
						ID = task.Id,
						Title = task.Title,
						Description = task.Description,
						Deadline = task.Deadline,
						Status = singleStatus
					});
				}

				employeesListViewModel.EmployeesList.Add(new EmployeeViewModel
				{
					ID = employee.ID,
					Name = employee.Name,
					Surname = employee.Surname,
					Email = employee.Email,
					Position = positionList,
					Tasks = tasksLVM,
				});

			}
			return employeesListViewModel; 
		}
	}
}
