using Application.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;


namespace WebAPI.Controllers
{
	public class AuthController : Controller
	{

		private readonly UsersService _usersService;


        public AuthController(UsersService usersService)
		{
            _usersService = usersService;

        }

		[HttpPost]
		public IActionResult Register( RegisterUserRequest request)
		{
			var token = _usersService.Register(request.Name, request.Email, request.Password);
			Response.Cookies.Append("JwtCookie", token);

			return Redirect("/Home/Index");
		}

		[HttpGet]
		public IActionResult Register()
		{

			return View();
		}

		[HttpPost]
        public  IActionResult Login(LoginUserRequest request)
        {
			var token = _usersService.Login(request.Name, request.Email, request.Password);

            if (token == String.Empty)
            {
                return View();
            }
            else
            {
                Response.Cookies.Append("JwtCookie", token);
            }

			return Redirect("/Home/Index");
		}

        [HttpGet]
        public IActionResult Login()
        {


            return View();
        }


    }
}
