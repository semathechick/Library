using NArchitecture.Core.Application.Responses;

namespace Application.Features.BookMembers.Commands.Delete;

public class DeletedBookMemberResponse : IResponse
{
    public Guid Id { get; set; }
}