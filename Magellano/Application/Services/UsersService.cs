using Application.Interfaces;
using Application.Interfaces.Auth;
using Domain;
//using Persistence;

namespace Application.Services
{
    public class UsersService
    {
        IUsersDbContext _usersDbContext;
        IJwtProvider _jwtProvider;
        public UsersService(IUsersDbContext usersDbContext, IJwtProvider jwtProvider)
        {
            _usersDbContext = usersDbContext;
            _jwtProvider = jwtProvider;
        }
        public string Register (string userName, string email, string password)
        {
            var hashedPassword = password; //Добавить кэширование

            var user = User.Create(Guid.NewGuid(), userName, password, email);

            _usersDbContext.Users.Add(user);
            _usersDbContext.SaveChanges(); //сделать метод ассинхронным

			var token = _jwtProvider.GenerateToken(user);
			return token;
		}


        public string Login(string userName, string email, string password)
        {
            User user = new User();
            string token = string.Empty;
            var result = false;

            if (email != null)
            {
                var users = _usersDbContext.Users;
                user = users.FirstOrDefault(u => u.Email == email); //убрать екеспетино в случае логина перекидывать на глав
            }


            if (user is not null && password != null && password == user.Password)
            {
                result = true;
                token = _jwtProvider.GenerateToken(user);
            }

            if (result == false)
            {
                Console.WriteLine("Failed to login");//logger
                //throw new Exception("Failed to login");
            }


            return token;
        }
    }
}
