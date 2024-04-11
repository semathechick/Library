using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CategoryBooks.Queries.GetList;

public class GetListCategoryBookQuery : IRequest<GetListResponse<GetListCategoryBookListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCategoryBookQueryHandler : IRequestHandler<GetListCategoryBookQuery, GetListResponse<GetListCategoryBookListItemDto>>
    {
        private readonly ICategoryBookRepository _categoryBookRepository;
        private readonly IMapper _mapper;

        public GetListCategoryBookQueryHandler(ICategoryBookRepository categoryBookRepository, IMapper mapper)
        {
            _categoryBookRepository = categoryBookRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCategoryBookListItemDto>> Handle(GetListCategoryBookQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CategoryBook> categoryBooks = await _categoryBookRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCategoryBookListItemDto> response = _mapper.Map<GetListResponse<GetListCategoryBookListItemDto>>(categoryBooks);
            return response;
        }
    }
}