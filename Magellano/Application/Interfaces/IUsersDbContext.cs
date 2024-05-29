using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace Application.Interfaces
{
    public interface IUsersDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        public int SaveChanges();

        public DbSet<User> Users { get; set; }
        public DbSet<NFT> NFTs { get; set; }
    }
}
