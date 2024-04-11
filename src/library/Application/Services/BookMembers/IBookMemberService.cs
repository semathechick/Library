using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookMembers;

public interface IBookMemberService
{
    Task<BookMember?> GetAsync(
        Expression<Func<BookMember, bool>> predicate,
        Func<IQueryable<BookMember>, IIncludableQueryable<BookMember, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BookMember>?> GetListAsync(
        Expression<Func<BookMember, bool>>? predicate = null,
        Func<IQueryable<BookMember>, IOrderedQueryable<BookMember>>? orderBy = null,
        Func<IQueryable<BookMember>, IIncludableQueryable<BookMember, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BookMember> AddAsync(BookMember bookMember);
    Task<BookMember> UpdateAsync(BookMember bookMember);
    Task<BookMember> DeleteAsync(BookMember bookMember, bool permanent = false);
}
