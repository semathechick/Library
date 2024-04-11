using Application.Features.Books.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.Books.Commands.Create;

public class CreateBookCommand : IRequest<CreatedBookResponse>
{
    public string ISBN { get; set; }
    public string Name { get; set; }
    public int Pages { get; set; }
    public BookStatus? Status { get; set; }
    public string? Language { get; set; }
    public int UnitsInStock { get; set; }
    

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreatedBookResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly BookBusinessRules _bookBusinessRules;

        public CreateBookCommandHandler(IMapper mapper, IBookRepository bookRepository,
                                         BookBusinessRules bookBusinessRules)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _bookBusinessRules = bookBusinessRules;
        }

        public async Task<CreatedBookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = _mapper.Map<Book>(request);

            await _bookRepository.AddAsync(book);

            CreatedBookResponse response = _mapper.Map<CreatedBookResponse>(book);
            return response;
        }
    }
}