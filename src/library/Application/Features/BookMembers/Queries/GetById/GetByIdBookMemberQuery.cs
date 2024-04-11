using Application.Features.BookMembers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BookMembers.Queries.GetById;

public class GetByIdBookMemberQuery : IRequest<GetByIdBookMemberResponse>
{
    public Guid Id { get; set; }

    public class GetByIdBookMemberQueryHandler : IRequestHandler<GetByIdBookMemberQuery, GetByIdBookMemberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookMemberRepository _bookMemberRepository;
        private readonly BookMemberBusinessRules _bookMemberBusinessRules;

        public GetByIdBookMemberQueryHandler(IMapper mapper, IBookMemberRepository bookMemberRepository, BookMemberBusinessRules bookMemberBusinessRules)
        {
            _mapper = mapper;
            _bookMemberRepository = bookMemberRepository;
            _bookMemberBusinessRules = bookMemberBusinessRules;
        }

        public async Task<GetByIdBookMemberResponse> Handle(GetByIdBookMemberQuery request, CancellationToken cancellationToken)
        {
            BookMember? bookMember = await _bookMemberRepository.GetAsync(predicate: bm => bm.Id == request.Id, cancellationToken: cancellationToken);
            await _bookMemberBusinessRules.BookMemberShouldExistWhenSelected(bookMember);

            GetByIdBookMemberResponse response = _mapper.Map<GetByIdBookMemberResponse>(bookMember);
            return response;
        }
    }
}