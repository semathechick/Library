using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BookMembers.Queries.GetList;

public class GetListBookMemberListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }
}