using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BookPublisherRepository : EfRepositoryBase<BookPublisher, Guid, BaseDbContext> , IBookPublisherRepository
{
    protected readonly DbContext _context;

    
    public BookPublisherRepository(BaseDbContext context) : base(context)
    {
        
        
    }
    
    public async Task SaveChangesAsync()
         {
                await _context.SaveChangesAsync();  
         }


        
    
}