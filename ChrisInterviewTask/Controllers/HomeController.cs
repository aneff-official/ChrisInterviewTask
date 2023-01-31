using System.Diagnostics;
using ChrisInterviewTask.Models;
using ChrisInterviewTask.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChrisInterviewTask.Controllers
{
	public class HomeController : Controller
	{
		private readonly IPostCodeService _postCodeService;

		public HomeController(IPostCodeService postCodeService)
		{
			_postCodeService = postCodeService;
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> PostCodeInfo(string postCode)
		{
			var result = await _postCodeService.Get(postCode);
			return Ok(result);
		}
	}
}