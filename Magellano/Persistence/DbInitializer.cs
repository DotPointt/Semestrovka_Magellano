using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer
    {
        public static void Initialize(UsersDbContext context)
        {
            context.Database.EnsureCreated();
            Console.WriteLine("[INF] Database Connected");
        }
    }
}
