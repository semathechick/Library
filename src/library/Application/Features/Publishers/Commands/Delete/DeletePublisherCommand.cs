using Application.Features.BookPublishers.Rules;
using Application.Features.Publishers.Constants;
using Application.Features.Publishers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Publishers.Commands.Delete;

public class DeletePublisherCommand : IRequest<DeletedPublisherResponse>
{
    public Guid Id { get; set; }

    public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand, DeletedPublisherResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPublisherRepository _publisherRepository;
        private readonly PublisherBusinessRules _publisherBusinessRules;

        public DeletePublisherCommandHandler(IMapper mapper, IPublisherRepository publisherRepository,
                                         PublisherBusinessRules publisherBusinessRules)
        {
            _mapper = mapper;
            _publisherRepository = publisherRepository;
            _publisherBusinessRules = publisherBusinessRules;
        }

        public async Task<DeletedPublisherResponse> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
        {
            Publisher? publisher = await _publisherRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            

            

                await _publisherBusinessRules.PublisherShouldExistWhenSelected(publisher);


               await  _publisherRepository.DeleteAsync(publisher!);
                DeletedPublisherResponse response = _mapper.Map<DeletedPublisherResponse>(publisher);
            return response;
        }
    }
}