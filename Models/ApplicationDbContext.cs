using Aplikacja_ASP_MVC.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;


namespace Aplikacja_ASP_MVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        { }

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
		//protected override void OnConfiguring(DbContextOptionsBuilder options)
		//{
		//	if (!options.IsConfigured)
		//	{
		//		options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DefaultConnection;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		//	}
		//}

		public DbSet<Employee> Employees { get; set; }
        public virtual DbSet<TaskToWork> Tasks { get; set; }
    }
}
