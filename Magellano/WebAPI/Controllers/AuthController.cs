using Application.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;


namespace WebAPI.Controllers
{
	public class AuthController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public AuthController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public static  IResult Register( RegisterUserRequest request,UsersService usersService)
		{
			usersService.Register(request.Name, request.Email, request.Password);

			return Results.Ok();
		}

        public static IResult Login(LoginUserRequest request, UsersService usersService)
        {
			var token = usersService.Login(request.Name, request.Email, request.Password);

            return Results.Ok(token);
        }

        public IActionResult Privacy()	
        {
            return View();
        }

    }
}
