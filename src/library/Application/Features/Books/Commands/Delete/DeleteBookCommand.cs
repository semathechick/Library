using Application.Features.Books.Constants;
using Application.Features.Books.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Books.Commands.Delete;

public class DeleteBookCommand : IRequest<DeletedBookResponse>
{
    public Guid Id { get; set; }

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, DeletedBookResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly BookBusinessRules _bookBusinessRules;
        private readonly IBookPublisherRepository _bookPublisherRepository;
        public DeleteBookCommandHandler(IMapper mapper, IBookRepository bookRepository,
                                         BookBusinessRules bookBusinessRules, IBookPublisherRepository bookPublisherRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _bookBusinessRules = bookBusinessRules;
        }

        public async Task<DeletedBookResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book? book = await _bookRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _bookBusinessRules.BookShouldExistWhenSelected(book);

            await _bookRepository.DeleteAsync(book);
            

            DeletedBookResponse response = _mapper.Map<DeletedBookResponse>(book);
            return response;
        }
    }
}