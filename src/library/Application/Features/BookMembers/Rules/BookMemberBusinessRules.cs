using Application.Features.BookMembers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BookMembers.Rules;

public class BookMemberBusinessRules : BaseBusinessRules
{
    private readonly IBookMemberRepository _bookMemberRepository;
    private readonly ILocalizationService _localizationService;

    public BookMemberBusinessRules(IBookMemberRepository bookMemberRepository, ILocalizationService localizationService)
    {
        _bookMemberRepository = bookMemberRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BookMembersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BookMemberShouldExistWhenSelected(BookMember? bookMember)
    {
        if (bookMember == null)
            await throwBusinessException(BookMembersBusinessMessages.BookMemberNotExists);
    }

    public async Task BookMemberIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BookMember? bookMember = await _bookMemberRepository.GetAsync(
            predicate: bm => bm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BookMemberShouldExistWhenSelected(bookMember);
    }
}