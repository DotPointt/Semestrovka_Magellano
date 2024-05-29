using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

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
		public IActionResult Upload()
        {
            return View();
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
