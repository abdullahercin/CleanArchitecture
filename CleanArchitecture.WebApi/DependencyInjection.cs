using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.WebApi.Services;

namespace CleanArchitecture.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserManager>();
            
            return services;
        }
    }
}
