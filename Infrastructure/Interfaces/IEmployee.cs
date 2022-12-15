using Aplikacja_ASP_MVC.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aplikacja_ASP_MVC.Infrastructure.Interfaces
{
	public interface IEmployee
	{
		Task<EmployeeViewModel> OpenAddingEmployee();
		Task SaveEmployee(EmployeeViewModel evm);
		Task RemoveEmployee(int id);
	}
}
