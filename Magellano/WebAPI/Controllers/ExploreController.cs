using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using WebAPI.Models;
using Domain;
using System.Reflection;



namespace WebAPI.Controllers
{
	public class ExploreController : Controller
	{
        private UsersDbContext db;
        public ExploreController(UsersDbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(string? SortParametr = "Price")
		{
            var nfts = await db.NFTs.ToListAsync();
            var sortedNFTs = nfts.OrderBy(nft => GetFieldValue(nft, SortParametr)).ToList();

            var model = new HomeControllerViewModel
            {
                Users = await db.Users.ToListAsync(),
                NFTs = sortedNFTs
            };

            return View(model);
		}

        public static object GetFieldValue(object obj, string fieldName)
        {
            Type type = obj.GetType();
            PropertyInfo propertyInfo = type.GetProperty(fieldName);
            if (propertyInfo != null && propertyInfo.CanRead)
            {
                return propertyInfo.GetValue(obj);
            }
            return null;
        }

        public string Api()
		{


            return "WOOOOOOOOOOOOOOOOOOOOOOORKS";
		}
	}
}
