using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public User() { }
        private User(Guid id, string userName, string passwordHash, string email) 
        {
            Id = id;
            Name = userName;
            Password = passwordHash;
            Email = email;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public double? NetWorth { get; set; }
        public string? PhotoUrl { get; set; }
        public List<NFT>? UserNFTs { get; set; } = new();

        public static User Create(Guid id, string userName, string passwordHash, string email)
        {
            return new User(id, userName, passwordHash, email);
        }
    }
}
