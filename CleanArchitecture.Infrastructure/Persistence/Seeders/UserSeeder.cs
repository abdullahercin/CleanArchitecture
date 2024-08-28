using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Seeders
{
    public class UserSeeder : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var initialUserId = Guid.Parse("2798212b-3e5d-4556-8629-a64eb70da4a8");

            var initialUser = new AppUser
            {
                Id = initialUserId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@localhost",
                NormalizedEmail = "ADMIN@LOCALHOST",
                EmailConfirmed = true,
                CreatedByUserId = initialUserId.ToString(),
                CreatedOn = new DateTimeOffset(new DateTime(2024,8,28)),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                FirstName = "Abdullah",
                LastName = "Erçin",
                LockoutEnabled = false,
                AccessFailedCount = 0,
            };

            initialUser.PasswordHash = new PasswordHasher<AppUser>().HashPassword(initialUser, "Admin123");

            builder.HasData(initialUser);
        }
    }
}
