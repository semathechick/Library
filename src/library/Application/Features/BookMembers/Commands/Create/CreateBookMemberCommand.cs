using Application.Features.BookMembers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BookMembers.Commands.Create;

public class CreateBookMemberCommand : IRequest<CreatedBookMemberResponse>
{
    public Guid BookId { get; set; }
    public Guid MemberId { get; set; }

    public class CreateBookMemberCommandHandler : IRequestHandler<CreateBookMemberCommand, CreatedBookMemberResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookMemberRepository _bookMemberRepository;
        private readonly BookMemberBusinessRules _bookMemberBusinessRules;

        public CreateBookMemberCommandHandler(IMapper mapper, IBookMemberRepository bookMemberRepository,
                                         BookMemberBusinessRules bookMemberBusinessRules)
        {
            _mapper = mapper;
            _bookMemberRepository = bookMemberRepository;
            _bookMemberBusinessRules = bookMemberBusinessRules;
        }

        public async Task<CreatedBookMemberResponse> Handle(CreateBookMemberCommand request, CancellationToken cancellationToken)
        {
            BookMember bookMember = _mapper.Map<BookMember>(request);

            await _bookMemberRepository.AddAsync(bookMember);

            CreatedBookMemberResponse response = _mapper.Map<CreatedBookMemberResponse>(bookMember);
            return response;
        }
    }
}