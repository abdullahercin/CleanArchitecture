using CleanArchitecture.Application.Features.ChatSessions.Commands.Create;
using CleanArchitecture.Application.Features.ChatSessions.Queries.GetAll;
using CleanArchitecture.Application.Features.ChatSessions.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers;

public class ChatSessionsController(IMediator mediator) : ApiControllerBase(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await Mediatr.Send(new ChatSessionGetAllQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await Mediatr.Send(new ChatSessionGetByIdQuery(id), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(ChatSessionCreateCommand command, CancellationToken cancellationToken)
    {
        var response = await Mediatr.Send(command, cancellationToken);
        return Ok(response);
    }
}