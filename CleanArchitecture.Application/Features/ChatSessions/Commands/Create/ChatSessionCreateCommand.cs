using CleanArchitecture.Application.Common.Models.General;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.ValueObjects;
using MediatR;

namespace CleanArchitecture.Application.Features.ChatSessions.Commands.Create
{
    public class ChatSessionCreateCommand: IRequest<ResponseDto<Guid>>
    {
        public GptModelType Model { get; set; }
        public string? Content { get; set; }

        public ChatSession ToChatSession(Guid userId)
        {
            return new ChatSession
            {
                Id=Ulid.NewUlid().ToGuid(),
                Model =Model,
                AppUserId = userId,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = userId.ToString(),
                Title = Content!.Length > 50 ? Content[..50] : Content,
                Threads =
                [
                    new ChatThread
                    {
                        Id = Ulid.NewUlid().ToString(),
                        Messages =
                        [
                            new ChatMessage
                            {
                                Id = Ulid.NewUlid().ToString(),
                                Model = Model,
                                Type = ChatMessageType.System,
                                Content = "You're a very helpful and happy asssitant which loves to help people.",
                                CreatedOn = DateTimeOffset.Now
                            },
                            new ChatMessage
                            {
                                Id = Ulid.NewUlid().ToString(),
                                Model = Model,
                                Type = ChatMessageType.User,
                                Content = Content,
                                CreatedOn = DateTimeOffset.Now
                            }
                        ]
                    }
                ]
            };
        }
    }
}
