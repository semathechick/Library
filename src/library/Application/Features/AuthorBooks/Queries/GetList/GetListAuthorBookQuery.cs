using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.AuthorBooks.Queries.GetList;

public class GetListAuthorBookQuery : IRequest<GetListResponse<GetListAuthorBookListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAuthorBookQueryHandler : IRequestHandler<GetListAuthorBookQuery, GetListResponse<GetListAuthorBookListItemDto>>
    {
        private readonly IAuthorBookRepository _authorBookRepository;
        private readonly IMapper _mapper;

        public GetListAuthorBookQueryHandler(IAuthorBookRepository authorBookRepository, IMapper mapper)
        {
            _authorBookRepository = authorBookRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAuthorBookListItemDto>> Handle(GetListAuthorBookQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AuthorBook> authorBooks = await _authorBookRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAuthorBookListItemDto> response = _mapper.Map<GetListResponse<GetListAuthorBookListItemDto>>(authorBooks);
            return response;
        }
    }
}