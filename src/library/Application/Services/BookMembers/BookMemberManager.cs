using Application.Features.BookMembers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BookMembers;

public class BookMemberManager : IBookMemberService
{
    private readonly IBookMemberRepository _bookMemberRepository;
    private readonly BookMemberBusinessRules _bookMemberBusinessRules;

    public BookMemberManager(IBookMemberRepository bookMemberRepository, BookMemberBusinessRules bookMemberBusinessRules)
    {
        _bookMemberRepository = bookMemberRepository;
        _bookMemberBusinessRules = bookMemberBusinessRules;
    }

    public async Task<BookMember?> GetAsync(
        Expression<Func<BookMember, bool>> predicate,
        Func<IQueryable<BookMember>, IIncludableQueryable<BookMember, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BookMember? bookMember = await _bookMemberRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bookMember;
    }

    public async Task<IPaginate<BookMember>?> GetListAsync(
        Expression<Func<BookMember, bool>>? predicate = null,
        Func<IQueryable<BookMember>, IOrderedQueryable<BookMember>>? orderBy = null,
        Func<IQueryable<BookMember>, IIncludableQueryable<BookMember, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BookMember> bookMemberList = await _bookMemberRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bookMemberList;
    }

    public async Task<BookMember> AddAsync(BookMember bookMember)
    {
        BookMember addedBookMember = await _bookMemberRepository.AddAsync(bookMember);

        return addedBookMember;
    }

    public async Task<BookMember> UpdateAsync(BookMember bookMember)
    {
        BookMember updatedBookMember = await _bookMemberRepository.UpdateAsync(bookMember);

        return updatedBookMember;
    }

    public async Task<BookMember> DeleteAsync(BookMember bookMember, bool permanent = false)
    {
        BookMember deletedBookMember = await _bookMemberRepository.DeleteAsync(bookMember);

        return deletedBookMember;
    }
}
