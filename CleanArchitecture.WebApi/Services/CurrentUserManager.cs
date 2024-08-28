using System.Security.Claims;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.WebApi.Services
{
    public class CurrentUserManager(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        public Guid UserId => GetUserId();

        private Guid GetUserId()
        {
            return Guid.Parse("2798212b-3e5d-4556-8629-a64eb70da4a8"); //jwt kurulunca kaldırılacak

            var userId = httpContextAccessor.HttpContext?.User.FindFirstValue("uid");
            return string.IsNullOrEmpty(userId) ? Guid.Empty : Guid.Parse(userId);
        }
    }
}
