using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Publishers.Queries.GetList;

public class GetListPublisherQuery : IRequest<GetListResponse<GetListPublisherListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPublisherQueryHandler : IRequestHandler<GetListPublisherQuery, GetListResponse<GetListPublisherListItemDto>>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public GetListPublisherQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPublisherListItemDto>> Handle(GetListPublisherQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Publisher> publishers = await _publisherRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPublisherListItemDto> response = _mapper.Map<GetListResponse<GetListPublisherListItemDto>>(publishers);
            return response;
        }
    }
}