using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public double? NetWorth { get; set; }
        public string? PhotoUrl { get; set; }
        public List<NFT>? UserNFTs { get; set; } = new();
    }
}
