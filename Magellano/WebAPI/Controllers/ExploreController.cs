using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
	public class ExploreController : Controller
	{
		//public ApplicationDbContext DbContext;

		public IActionResult Index()
		{
			return View();
		}

		public string Api()
		{


            return "WOOOOOOOOOOOOOOOOOOOOOOORKS";
		}
	}
}
