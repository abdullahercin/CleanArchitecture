using CleanArchitecture.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.ChatSessions.Queries.GetById;

public sealed class ChatSessionGetByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<ChatSessionGetByIdQuery, ChatSessionGetByIdDto>
{
    public async Task<ChatSessionGetByIdDto> Handle(ChatSessionGetByIdQuery request, CancellationToken cancellationToken)
    {
        var chatSession = await context.ChatSessions.AsNoTracking().FirstOrDefaultAsync(p=>p.Id==request.Id,cancellationToken);
        return ChatSessionGetByIdDto.MapFromChatSession(chatSession!)!;
    }
}