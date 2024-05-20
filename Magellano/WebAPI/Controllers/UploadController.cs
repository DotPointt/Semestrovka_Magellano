using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace WebAPI.Controllers
{
	[Controller]
	public class UploadController : Controller
    {
        private UsersDbContext db;
        public UploadController(UsersDbContext context)
        {
            db = context;
        }

		[HttpGet]
		public IActionResult Upload()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Upload(NFT NFT)
		{
			try
			{
				db.NFTs.Add(NFT);//Добавить привязку к пользователю
				await db.SaveChangesAsync();
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
