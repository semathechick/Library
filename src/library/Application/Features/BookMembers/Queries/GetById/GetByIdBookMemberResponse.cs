using NArchitecture.Core.Application.Responses;

namespace Application.Features.BookMembers.Queries.GetById;

public class GetByIdBookMemberResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
}