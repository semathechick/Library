using NArchitecture.Core.Application.Responses;

namespace Application.Features.BookMembers.Commands.Update;

public class UpdatedBookMemberResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
}