using CleanArchitecture.Application.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.ChatSessions.Queries.GetById;

public class ChatSessionGetByIdQueryValidator:AbstractValidator<ChatSessionGetByIdQuery>
{
    private readonly IApplicationDbContext _context;
    public ChatSessionGetByIdQueryValidator(IApplicationDbContext context)
    {
        _context = context;
        RuleFor(p => p.Id).NotEmpty().NotNull()
            .WithMessage("Id değeri zorunludur")
            .MustAsync(BeValidIdAsync);
    }

    private Task<bool> BeValidIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _context.ChatSessions.AnyAsync(p => p.Id == id, cancellationToken);
    }
}