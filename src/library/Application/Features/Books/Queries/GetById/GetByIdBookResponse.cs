using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Books.Queries.GetById;

public class GetByIdBookResponse : IResponse
{
    public Guid Id { get; set; }
    public string ISBN { get; set; }
    public string Name { get; set; }
    public int Pages { get; set; }
    public BookStatus? Status { get; set; }
    public string? Language { get; set; }
    public int UnitsInStock { get; set; }
    public Guid PublisherId { get; set; }
}