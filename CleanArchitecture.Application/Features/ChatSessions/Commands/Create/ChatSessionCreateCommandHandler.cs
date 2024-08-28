using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models.General;
using CleanArchitecture.Application.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Features.ChatSessions.Commands.Create;

public class ChatSessionCreateCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
    : IRequestHandler<ChatSessionCreateCommand, ResponseDto<Guid>>
{
    public async Task<ResponseDto<Guid>> Handle(ChatSessionCreateCommand request, CancellationToken cancellationToken)
    {
        var chatSession = request.ToChatSession(currentUserService.UserId);
        context.ChatSessions.Add(chatSession);
        await context.SaveChangesAsync(cancellationToken);
        return new ResponseDto<Guid>(chatSession.Id, "A new chat session was created successfully.");
    }
}