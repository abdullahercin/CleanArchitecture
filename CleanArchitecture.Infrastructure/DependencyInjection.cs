using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));

        services.AddScoped<IApplicationDbContext,ApplicationDbContext>();

        return services;
    }
}