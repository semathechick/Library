using NArchitecture.Core.Application.Responses;

namespace Application.Features.BookMembers.Commands.Create;

public class CreatedBookMemberResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
}