using Aplikacja_ASP_MVC.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aplikacja_ASP_MVC.Infrastructure.Interfaces
{
	public interface ITask
	{
		Task<TaskViewModel> OpenAddingTask();
		Task SaveTask(TaskViewModel tvm);
		Task SaveStatus(int taskid, string status);
	}
}
