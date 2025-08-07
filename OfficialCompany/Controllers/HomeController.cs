using Microsoft.AspNetCore.Mvc;
using OfficialCompany.Core.Services.Interfaces;
using OfficialCompany.DataLayer.Entities;
using OfficialCompany.Models;
using System.Diagnostics;

namespace OfficialCompany.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly INewsService _service;
		public HomeController(ILogger<HomeController> logger, INewsService service)
		{
			_logger = logger;
			_service = service;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetLastNews()
		{
			var res = _service.GetLastNews();
			return PartialView("_NewsPartial", res);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
