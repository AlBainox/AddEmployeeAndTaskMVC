using Aplikacja_ASP_MVC.Infrastructure.Interfaces;
using Aplikacja_ASP_MVC.Infrastructure.Models;
using Aplikacja_ASP_MVC.Infrastructure.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aplikacja_ASP_MVC.Models;

namespace Aplikacja_ASP_MVC.Services
{
    public class EmployeeService : IEmployee
	{
		public EmployeeService(ApplicationDbContext dbContext)
		{
			this.DbContext = dbContext;
		}

		private readonly ApplicationDbContext DbContext;
		public Task<EmployeeViewModel> OpenAddingEmployee()
		{
			var evm = new EmployeeViewModel();
			evm.Position = new List<string>(){
			new string("Programmer"),
			new string("QA"),
			new string("Project Manager")
			};
			return Task.FromResult(evm);
		}

		public async Task RemoveEmployee(int id)
		{
			var employeeToRemove = await DbContext.Employees.Where(x => x.ID == id).Include(w => w.Tasks).FirstOrDefaultAsync();
			DbContext.Employees.Remove(employeeToRemove);
			await DbContext.SaveChangesAsync();
		}

		public async Task SaveEmployee(EmployeeViewModel evm)
		{

			DbContext.Employees.Add(new Employee
			{
				Name = evm.Name,
				Surname = evm.Surname,
				Email = evm.Email,
				Position = evm.Position.FirstOrDefault().ToString(),
			});
			await DbContext.SaveChangesAsync();
		}
	}
}
