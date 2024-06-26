using Application.Features.BookPublishers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BookPublishers.Commands.Create;

public class CreateBookPublisherCommand : IRequest<CreatedBookPublisherResponse>
{
    public Guid BookId { get; set; }
    public Guid PublisherId { get; set; }

    public class CreateBookPublisherCommandHandler : IRequestHandler<CreateBookPublisherCommand, CreatedBookPublisherResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookPublisherRepository _bookPublisherRepository;
        private readonly BookPublisherBusinessRules _bookPublisherBusinessRules;

        public CreateBookPublisherCommandHandler(IMapper mapper, IBookPublisherRepository bookPublisherRepository,
                                         BookPublisherBusinessRules bookPublisherBusinessRules)
        {
            _mapper = mapper;
            _bookPublisherRepository = bookPublisherRepository;
            _bookPublisherBusinessRules = bookPublisherBusinessRules;
        }

        public async Task<CreatedBookPublisherResponse> Handle(CreateBookPublisherCommand request, CancellationToken cancellationToken)
        {
            BookPublisher bookPublisher = _mapper.Map<BookPublisher>(request);

            await _bookPublisherRepository.AddAsync(bookPublisher);

            CreatedBookPublisherResponse response = _mapper.Map<CreatedBookPublisherResponse>(bookPublisher);
            return response;
        }
    }
}