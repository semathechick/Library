using Application.Features.Authors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Authors.Commands.Create;

public class CreateAuthorCommand : IRequest<CreatedAuthorResponse>
{
    public string Name { get; set; }
    public string SurName { get; set; }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, CreatedAuthorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorBusinessRules _authorBusinessRules;

        public CreateAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository,
                                         AuthorBusinessRules authorBusinessRules)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
            _authorBusinessRules = authorBusinessRules;
        }

        public async Task<CreatedAuthorResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = _mapper.Map<Author>(request);

            await _authorRepository.AddAsync(author);

            CreatedAuthorResponse response = _mapper.Map<CreatedAuthorResponse>(author);
            return response;
        }
    }
}