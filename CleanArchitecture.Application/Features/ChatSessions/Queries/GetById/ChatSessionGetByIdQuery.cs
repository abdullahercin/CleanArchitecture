using MediatR;

namespace CleanArchitecture.Application.Features.ChatSessions.Queries.GetById
{
    public sealed class ChatSessionGetByIdQuery : IRequest<ChatSessionGetByIdDto>
    {
        public Guid Id { get; set; }

        public ChatSessionGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
