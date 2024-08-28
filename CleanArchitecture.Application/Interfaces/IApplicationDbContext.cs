using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ChatSession> ChatSessions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancelletionToken);
        int SaveChanges();
    }
}
