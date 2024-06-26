using Application.Features.AuthorBooks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AuthorBooks.Commands.Update;

public class UpdateAuthorBookCommand : IRequest<UpdatedAuthorBookResponse>
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public Guid BookId { get; set; }

    public class UpdateAuthorBookCommandHandler : IRequestHandler<UpdateAuthorBookCommand, UpdatedAuthorBookResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorBookRepository _authorBookRepository;
        private readonly AuthorBookBusinessRules _authorBookBusinessRules;

        public UpdateAuthorBookCommandHandler(IMapper mapper, IAuthorBookRepository authorBookRepository,
                                         AuthorBookBusinessRules authorBookBusinessRules)
        {
            _mapper = mapper;
            _authorBookRepository = authorBookRepository;
            _authorBookBusinessRules = authorBookBusinessRules;
        }

        public async Task<UpdatedAuthorBookResponse> Handle(UpdateAuthorBookCommand request, CancellationToken cancellationToken)
        {
            AuthorBook? authorBook = await _authorBookRepository.GetAsync(predicate: ab => ab.Id == request.Id, cancellationToken: cancellationToken);
            await _authorBookBusinessRules.AuthorBookShouldExistWhenSelected(authorBook);
            authorBook = _mapper.Map(request, authorBook);

            await _authorBookRepository.UpdateAsync(authorBook!);

            UpdatedAuthorBookResponse response = _mapper.Map<UpdatedAuthorBookResponse>(authorBook);
            return response;
        }
    }
}