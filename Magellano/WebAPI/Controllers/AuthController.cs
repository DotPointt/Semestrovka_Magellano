using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
	public class AuthController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public AuthController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Login()
		{
			return View();
		}


	}
}
