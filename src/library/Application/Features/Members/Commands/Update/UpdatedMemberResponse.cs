using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Members.Commands.Update;

public class UpdatedMemberResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
}