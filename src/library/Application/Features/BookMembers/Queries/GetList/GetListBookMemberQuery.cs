using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.BookMembers.Queries.GetList;

public class GetListBookMemberQuery : IRequest<GetListResponse<GetListBookMemberListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBookMemberQueryHandler : IRequestHandler<GetListBookMemberQuery, GetListResponse<GetListBookMemberListItemDto>>
    {
        private readonly IBookMemberRepository _bookMemberRepository;
        private readonly IMapper _mapper;

        public GetListBookMemberQueryHandler(IBookMemberRepository bookMemberRepository, IMapper mapper)
        {
            _bookMemberRepository = bookMemberRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBookMemberListItemDto>> Handle(GetListBookMemberQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BookMember> bookMembers = await _bookMemberRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBookMemberListItemDto> response = _mapper.Map<GetListResponse<GetListBookMemberListItemDto>>(bookMembers);
            return response;
        }
    }
}