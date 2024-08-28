using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.ChatSessions.Queries.GetAll
{
    public class ChatSessionGetAllQueryHandler(IApplicationDbContext context, ICurrentUserService service)
        : IRequestHandler<ChatSessionGetAllQuery, List<ChatSessionGetAllDto>>
    {
        public Task<List<ChatSessionGetAllDto>> Handle(ChatSessionGetAllQuery request, CancellationToken cancellationToken)
        {
            return context
                .ChatSessions
                .AsNoTracking()
                .Where(x => x.AppUserId == service.UserId)
                .OrderByDescending(cs=>cs.CreatedOn)
                .Select(x=>ChatSessionGetAllDto.MapFromChatSession(x))
                .ToListAsync(cancellationToken);
        }
    }
}
