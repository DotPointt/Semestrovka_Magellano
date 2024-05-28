using Microsoft.EntityFrameworkCore;
using Domain;
using Persistence.EntityTypeConfiguration;
using System.Reflection.Emit;
using Application.Interfaces;
using Domain.Common;


namespace Persistence
{
    public class UsersDbContext : DbContext, IUsersDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<NFT> NFTs { get; set; }
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();        
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedAt = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).UpdatedAt = DateTime.UtcNow;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			User Kamil = new User { Id = Guid.NewGuid(), Name = "kamil", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://sun9-22.userapi.com/impg/GE3rXihxDn3I2fzIjo9ZEUWjkbpBO5v21us8OQ/JRLStxrCBUE.jpg?size=2012x2160&quality=95&sign=03eb995a306ea3aa723bb8589f96c06f&type=album" };
			Random random = new Random();

			modelBuilder.Entity<User>().HasData(
				Kamil,
				new User { Id = Guid.NewGuid(), Name = "Alice", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://img.freepik.com/free-photo/smiley-woman-posing-outside_23-2148803575.jpg?t=st=1715960026~exp=1715963626~hmac=32a75169733fa873a23fb5009ac2c972a1ca77dd7b6c4a430bd1c5a6b4e3c396&w=1060", NetWorth = random.Next(1, 10) },
				new User { Id = Guid.NewGuid(), Name = "Sam", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://f.vividscreen.info/soft/e0645f6400315a8eaa44f5fad80b10ff/Robert-Downey-Jr-2880x1920.jpg", NetWorth = random.Next(1, 10) },				
				new User { Id = Guid.NewGuid(), Name = "Tom", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://img.freepik.com/free-photo/smiley-woman-posing-outside_23-2148803575.jpg?t=st=1715960026~exp=1715963626~hmac=32a75169733fa873a23fb5009ac2c972a1ca77dd7b6c4a430bd1c5a6b4e3c396&w=1060", NetWorth = random.Next(1, 10) },
				new User { Id = Guid.NewGuid(), Name = "Alice", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://img.freepik.com/free-photo/smiley-woman-posing-outside_23-2148803575.jpg?t=st=1715960026~exp=1715963626~hmac=32a75169733fa873a23fb5009ac2c972a1ca77dd7b6c4a430bd1c5a6b4e3c396&w=1060", NetWorth = random.Next(1, 10) },
				new User { Id = Guid.NewGuid(), Name = "Sam", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://img.freepik.com/free-photo/smiley-woman-posing-outside_23-2148803575.jpg?t=st=1715960026~exp=1715963626~hmac=32a75169733fa873a23fb5009ac2c972a1ca77dd7b6c4a430bd1c5a6b4e3c396&w=1060", NetWorth = random.Next(1, 10) },				
				new User { Id = Guid.NewGuid(), Name = "Tom", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://img.freepik.com/free-photo/smiley-woman-posing-outside_23-2148803575.jpg?t=st=1715960026~exp=1715963626~hmac=32a75169733fa873a23fb5009ac2c972a1ca77dd7b6c4a430bd1c5a6b4e3c396&w=1060", NetWorth = random.Next(1, 10) },
				new User { Id = Guid.NewGuid(), Name = "Alice", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://img.freepik.com/free-photo/smiley-woman-posing-outside_23-2148803575.jpg?t=st=1715960026~exp=1715963626~hmac=32a75169733fa873a23fb5009ac2c972a1ca77dd7b6c4a430bd1c5a6b4e3c396&w=1060", NetWorth = random.Next(1, 10) },
				new User { Id = Guid.NewGuid(), Name = "Sam", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://img.freepik.com/free-photo/smiley-woman-posing-outside_23-2148803575.jpg?t=st=1715960026~exp=1715963626~hmac=32a75169733fa873a23fb5009ac2c972a1ca77dd7b6c4a430bd1c5a6b4e3c396&w=1060", NetWorth = random.Next(1, 10) },				
				new User { Id = Guid.NewGuid(), Name = "Tom", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://img.freepik.com/free-photo/smiley-woman-posing-outside_23-2148803575.jpg?t=st=1715960026~exp=1715963626~hmac=32a75169733fa873a23fb5009ac2c972a1ca77dd7b6c4a430bd1c5a6b4e3c396&w=1060", NetWorth = random.Next(1, 10) },
				new User { Id = Guid.NewGuid(), Name = "Alice", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://img.freepik.com/free-photo/smiley-woman-posing-outside_23-2148803575.jpg?t=st=1715960026~exp=1715963626~hmac=32a75169733fa873a23fb5009ac2c972a1ca77dd7b6c4a430bd1c5a6b4e3c396&w=1060", NetWorth = random.Next(1, 10) },
				new User { Id = Guid.NewGuid(), Name = "Sam", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://img.freepik.com/free-photo/smiley-woman-posing-outside_23-2148803575.jpg?t=st=1715960026~exp=1715963626~hmac=32a75169733fa873a23fb5009ac2c972a1ca77dd7b6c4a430bd1c5a6b4e3c396&w=1060", NetWorth = random.Next(1, 10) },				
				new User { Id = Guid.NewGuid(), Name = "Tom", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://img.freepik.com/free-photo/smiley-woman-posing-outside_23-2148803575.jpg?t=st=1715960026~exp=1715963626~hmac=32a75169733fa873a23fb5009ac2c972a1ca77dd7b6c4a430bd1c5a6b4e3c396&w=1060", NetWorth = random.Next(1, 10) },
				new User { Id = Guid.NewGuid(), Name = "Alice", Email = RandomStringGenerator.GenerateRandomEmail(8), PhotoUrl = "https://img.freepik.com/free-photo/smiley-woman-posing-outside_23-2148803575.jpg?t=st=1715960026~exp=1715963626~hmac=32a75169733fa873a23fb5009ac2c972a1ca77dd7b6c4a430bd1c5a6b4e3c396&w=1060", NetWorth = random.Next(1, 10) },
				new User { Id = Guid.NewGuid(), Name = "Sam", Email = RandomStringGenerator.GenerateRandomEmail(8), NetWorth = random.Next(1, 10) }
		    );

			modelBuilder.Entity<NFT>().HasData(
				new NFT { Id = Guid.NewGuid(), Url = "https://img.freepik.com/free-vector/circle-hearts-set_78370-2859.jpg?size=626&ext=jpg", UserId = Kamil.Id, Price = random.Next(1, 10000), Name = RandomStringGenerator.GenerateRandomName(5) },
				new NFT { Id = Guid.NewGuid(), Url = "https://f.vividscreen.info/soft/e0645f6400315a8eaa44f5fad80b10ff/Robert-Downey-Jr-2880x1920.jpg", UserId = Kamil.Id, Price = random.Next(1, 10000), Name = RandomStringGenerator.GenerateRandomName(5) },
				new NFT { Id = Guid.NewGuid(), Url = "https://img.freepik.com/free-vector/circle-hearts-set_78370-2859.jpg?size=626&ext=jpg", UserId = Kamil.Id, Price = random.Next(1, 10000), Name = RandomStringGenerator.GenerateRandomName(5) },
				new NFT { Id = Guid.NewGuid(), Url = "https://img.freepik.com/free-vector/circle-hearts-set_78370-2859.jpg?size=626&ext=jpg", UserId = Kamil.Id, Price = random.Next(1, 10000), Name = RandomStringGenerator.GenerateRandomName(5) }
				);
		}


		public class RandomStringGenerator
		{
			private static Random random = new Random();

			public static string GenerateRandomEmail(int length)
			{
				const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
				return new string(Enumerable.Repeat(chars, length)
				  .Select(s => s[random.Next(s.Length)]).ToArray()) + "@example.com";
			}

			public static string GenerateRandomName(int length)
			{
				const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
				return "Name " + new string(Enumerable.Repeat(chars, length)
				  .Select(s => s[random.Next(s.Length)]).ToArray()) ;
			}
		}

	}
}
