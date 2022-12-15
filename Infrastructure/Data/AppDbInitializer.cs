using Aplikacja_ASP_MVC.Infrastructure.Models;
using Aplikacja_ASP_MVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Aplikacja_ASP_MVC.Infrastructure.Data
{
	public class AppDbInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
				context.Database.EnsureCreated();

				if (!context.Employees.Any())
				{
					context.Employees.AddRange(new List<Employee>()
					{
						new Employee()
						{
						Name = "Jan",
						Surname="Jankowski",
						Email= "jan@jankowski.pl",
						Position= "QA",
						Tasks= new List<TaskToWork>()
						{
							new TaskToWork() {
						Title= "Stworzyć komponent",
						Description = "Stworzyć komponent komunikaujący zsię z parentem w Angularze",
						Status = "NEW",
						Deadline = System.DateTime.Now,
							},
							new TaskToWork() {
						Title= "Napisać API",
						Description = "Stworzyć stworzyć REST api z metodami CRUD",
						Status = "NEW",
						Deadline = System.DateTime.Now,
							},
						},
						},
						new Employee()
						{
						Name = "Cezary",
						Surname="Ławniczak",
						Email= "cezary@Ławniczak.pl",
						Position= "QA",
						Tasks= new List<TaskToWork>()
						{
							new TaskToWork() {
						Title= "Napisać kontroler",
						Description = "Zaprojektować i stworzyć kontroler pod CRUDA",
						Status = "NEW",
						Deadline = System.DateTime.Now,
							},
							new TaskToWork() {
						Title= "Napisać widoki",
						Description = "Stworzyć widoki do akcji kontrolera",
						Status = "NEW",
						Deadline = System.DateTime.Now,
							},
						},
						},

					});
					context.SaveChanges();
				}
				
			}


		}

	}
}


