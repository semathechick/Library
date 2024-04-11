using Application.Features.CategoryBooks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CategoryBooks.Commands.Create;

public class CreateCategoryBookCommand : IRequest<CreatedCategoryBookResponse>
{
    public Guid BookId { get; set; }
    public Guid CategoryId { get; set; }

    public class CreateCategoryBookCommandHandler : IRequestHandler<CreateCategoryBookCommand, CreatedCategoryBookResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryBookRepository _categoryBookRepository;
        private readonly CategoryBookBusinessRules _categoryBookBusinessRules;

        public CreateCategoryBookCommandHandler(IMapper mapper, ICategoryBookRepository categoryBookRepository,
                                         CategoryBookBusinessRules categoryBookBusinessRules)
        {
            _mapper = mapper;
            _categoryBookRepository = categoryBookRepository;
            _categoryBookBusinessRules = categoryBookBusinessRules;
        }

        public async Task<CreatedCategoryBookResponse> Handle(CreateCategoryBookCommand request, CancellationToken cancellationToken)
        {
            CategoryBook categoryBook = _mapper.Map<CategoryBook>(request);

            await _categoryBookRepository.AddAsync(categoryBook);

            CreatedCategoryBookResponse response = _mapper.Map<CreatedCategoryBookResponse>(categoryBook);
            return response;
        }
    }
}