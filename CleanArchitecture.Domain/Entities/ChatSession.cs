using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Entities;

public sealed class ChatSession:EntityBase
{
    public string? Title { get; set; }
    public GptModelType Model { get; set; }
    public List<ChatThread> Threads { get; set; } = [];
    public Guid AppUserId { get; set; }
}