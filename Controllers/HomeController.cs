using Aplikacja_ASP_MVC.Infrastructure.ViewModel;
using Aplikacja_ASP_MVC.Infrastructure.Interfaces;
using Aplikacja_ASP_MVC.Models;
using Aplikacja_ASP_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace Aplikacja_ASP_MVC.Controllers
{
    public class HomeController : Controller
	{
		

		public HomeController(IHome homeService)
		{			
			this.homeService = homeService;
		}
		
		private readonly IHome homeService;

		public async Task<IActionResult> Index()
		{
			var result = await homeService.Index();
			return View(result);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
						

		

		
		

		

	}
}
