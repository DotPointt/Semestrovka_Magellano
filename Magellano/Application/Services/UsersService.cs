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
        public void Register (string userName, string email, string password)
        {
            var hashedPassword = password; //Добавить кэширование

            var user = User.Create(Guid.NewGuid(), userName, password, email);

            _usersDbContext.Users.Add(user);
            _usersDbContext.SaveChanges(); //сделать метод ассинхронным
        }


        public string Login(string userName, string email, string password)
        {
            var user = _usersDbContext.Users.First(u => u.Email == email) ?? throw new Exception();

            var result = password == user.Password;

            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
