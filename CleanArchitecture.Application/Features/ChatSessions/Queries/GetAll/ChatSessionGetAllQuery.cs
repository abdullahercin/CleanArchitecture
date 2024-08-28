using MediatR;

namespace CleanArchitecture.Application.Features.ChatSessions.Queries.GetAll
{
    public class ChatSessionGetAllQuery : IRequest<ChatSessionGetAllQuery>, IRequest<List<ChatSessionGetAllDto>>
    {
    }
}
