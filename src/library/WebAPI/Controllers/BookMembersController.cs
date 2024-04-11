using Application.Features.BookMembers.Commands.Create;
using Application.Features.BookMembers.Commands.Delete;
using Application.Features.BookMembers.Commands.Update;
using Application.Features.BookMembers.Queries.GetById;
using Application.Features.BookMembers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookMembersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookMemberCommand createBookMemberCommand)
    {
        CreatedBookMemberResponse response = await Mediator.Send(createBookMemberCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookMemberCommand updateBookMemberCommand)
    {
        UpdatedBookMemberResponse response = await Mediator.Send(updateBookMemberCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBookMemberResponse response = await Mediator.Send(new DeleteBookMemberCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBookMemberResponse response = await Mediator.Send(new GetByIdBookMemberQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBookMemberQuery getListBookMemberQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBookMemberListItemDto> response = await Mediator.Send(getListBookMemberQuery);
        return Ok(response);
    }
}