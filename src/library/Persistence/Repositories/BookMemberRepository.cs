using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BookMemberRepository : EfRepositoryBase<BookMember, Guid, BaseDbContext>, IBookMemberRepository
{
    public BookMemberRepository(BaseDbContext context) : base(context)
    {
    }
}