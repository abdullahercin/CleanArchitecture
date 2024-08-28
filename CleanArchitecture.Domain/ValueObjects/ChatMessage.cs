using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.ValueObjects;

public sealed class ChatMessage
{
    public string? Id { get; set; }
    public GptModelType Model { get; set; }
    public ChatMessageType Type { get; set; }
    public string? Content { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}