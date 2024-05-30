using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.IdentityModel.Tokens.Jwt;
using WebAPI.Models;

namespace WebAPI.Controllers
{
	[Controller]
	public class UploadController : Controller
    {
        private IUsersDbContext db;
        public UploadController(IUsersDbContext context)
        {
            db = context;
        }

		[HttpGet]
		public async Task<IActionResult> Upload()
        {
            var jwtToken = HttpContext.Request.Cookies["JwtCookie"];
            if (string.IsNullOrEmpty(jwtToken))
            {
                return Unauthorized();
            }
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);

            var Name = token.Claims.FirstOrDefault(c => c.Type == "userName")?.Value;

            //var PhotoUrl = token.Claims.FirstOrDefault(c => c.Type == "PhotoUrl")?.Value;
			var PhotoUrl =  await db.Users
            .Where(u => u.Name == Name)
            .Select(u => u.PhotoUrl)
            .FirstOrDefaultAsync();

            return View(new UploadViewModel(Name, PhotoUrl));
        }

		[HttpPost]
		public IActionResult Upload(NFT NFT)
		{
			try
			{
				db.NFTs.Add(NFT);//Добавить привязку к пользователю
				db.SaveChanges();
			}
			catch (Exception ex)
			{
				// Log the exception
				Console.WriteLine(ex.ToString());
				throw;
			}

			return View();
		}
	}
}
