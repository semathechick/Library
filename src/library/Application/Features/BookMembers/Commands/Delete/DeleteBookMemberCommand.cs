using Application.Features.BookMembers.Constants;
using Application.Features.BookMembers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BookMembers.Commands.Delete;

public class DeleteBookMemberCommand : IRequest<DeletedBookMemberResponse>
{
    public Guid Id { get; set; }

    public class DeleteBookMemberCommandHandler : IRequestHandler<DeleteBookMemberCommand, DeletedBookMemberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookMemberRepository _bookMemberRepository;
        private readonly BookMemberBusinessRules _bookMemberBusinessRules;

        public DeleteBookMemberCommandHandler(IMapper mapper, IBookMemberRepository bookMemberRepository,
                                         BookMemberBusinessRules bookMemberBusinessRules)
        {
            _mapper = mapper;
            _bookMemberRepository = bookMemberRepository;
            _bookMemberBusinessRules = bookMemberBusinessRules;
        }

        public async Task<DeletedBookMemberResponse> Handle(DeleteBookMemberCommand request, CancellationToken cancellationToken)
        {
            BookMember? bookMember = await _bookMemberRepository.GetAsync(predicate: bm => bm.Id == request.Id, cancellationToken: cancellationToken);
            await _bookMemberBusinessRules.BookMemberShouldExistWhenSelected(bookMember);

            await _bookMemberRepository.DeleteAsync(bookMember!);

            DeletedBookMemberResponse response = _mapper.Map<DeletedBookMemberResponse>(bookMember);
            return response;
        }
    }
}