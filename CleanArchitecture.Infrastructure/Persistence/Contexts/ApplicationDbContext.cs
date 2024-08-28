using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<AppUser, Role, Guid, AppUserClaim, AppUserRole, AppUserLogin, RoleClaim, AppUserToken>(options),
        IApplicationDbContext
{
    public DbSet<ChatSession> ChatSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}