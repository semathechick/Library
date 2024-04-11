using Application.Features.BookPublishers.Constants;
using Application.Features.BookPublishers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.BookPublishers.Commands.Delete;

public class DeleteBookPublisherCommand : IRequest<DeletedBookPublisherResponse>
{
    public Guid Id { get; set; }

    public class DeleteBookPublisherCommandHandler : IRequestHandler<DeleteBookPublisherCommand, DeletedBookPublisherResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookPublisherRepository _bookPublisherRepository;
        private readonly BookPublisherBusinessRules _bookPublisherBusinessRules;
        private readonly IBookRepository _bookRepository;
        private readonly IPublisherRepository _publisherRepository;
      

        public DeleteBookPublisherCommandHandler(IBookRepository bookRepository, IPublisherRepository publisherRepository, IMapper mapper, IBookPublisherRepository bookPublisherRepository, BookPublisherBusinessRules bookPublisherBusinessRules)
        {
            _bookRepository = bookRepository;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
            _bookPublisherRepository = bookPublisherRepository;
            _bookPublisherBusinessRules = bookPublisherBusinessRules;
            
            
        }



        public async Task<DeletedBookPublisherResponse> Handle(DeleteBookPublisherCommand request, CancellationToken cancellationToken)
        {
            
            BookPublisher? bookPublisher = await _bookPublisherRepository.GetAsync(predicate: bp => bp.Id == request.Id, cancellationToken: cancellationToken);


            
                
                await _bookPublisherBusinessRules.BookPublisherShouldExistWhenSelected(bookPublisher);


                

                
                await _bookPublisherRepository.DeleteAsync(bookPublisher);
               

            

                DeletedBookPublisherResponse response = _mapper.Map<DeletedBookPublisherResponse>(bookPublisher);
            return response;
        }

    }
}