using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Members.Queries.GetList;

public class GetListMemberListItemDto : IDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
}