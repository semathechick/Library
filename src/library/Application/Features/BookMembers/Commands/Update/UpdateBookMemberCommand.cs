using Application.Features.BookMembers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BookMembers.Commands.Update;

public class UpdateBookMemberCommand : IRequest<UpdatedBookMemberResponse>
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }

    public class UpdateBookMemberCommandHandler : IRequestHandler<UpdateBookMemberCommand, UpdatedBookMemberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookMemberRepository _bookMemberRepository;
        private readonly BookMemberBusinessRules _bookMemberBusinessRules;

        public UpdateBookMemberCommandHandler(IMapper mapper, IBookMemberRepository bookMemberRepository,
                                         BookMemberBusinessRules bookMemberBusinessRules)
        {
            _mapper = mapper;
            _bookMemberRepository = bookMemberRepository;
            _bookMemberBusinessRules = bookMemberBusinessRules;
        }

        public async Task<UpdatedBookMemberResponse> Handle(UpdateBookMemberCommand request, CancellationToken cancellationToken)
        {
            BookMember? bookMember = await _bookMemberRepository.GetAsync(predicate: bm => bm.Id == request.Id, cancellationToken: cancellationToken);
            await _bookMemberBusinessRules.BookMemberShouldExistWhenSelected(bookMember);
            bookMember = _mapper.Map(request, bookMember);

            await _bookMemberRepository.UpdateAsync(bookMember!);

            UpdatedBookMemberResponse response = _mapper.Map<UpdatedBookMemberResponse>(bookMember);
            return response;
        }
    }
}