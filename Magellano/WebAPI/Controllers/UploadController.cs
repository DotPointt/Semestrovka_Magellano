using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace WebAPI.Controllers
{
    public class UploadController : Controller
    {
        private UsersDbContext db;
        public UploadController(UsersDbContext context)
        {
            db = context;
        }

        public IActionResult Upload(User user)
        {
            db.Users.Add(user);
            db.SaveChangesAsync();
            return View();
        }

        public IActionResult Index1()
        {
            return View();
        }
    }
}
