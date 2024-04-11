using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Publisher : Entity<Guid>
{
    public Publisher(Guid id , string publisherName):base(id)
    {
        PublisherName = publisherName;
       
    }
    public Publisher() { }
    public string? PublisherName { get; set; }
    public virtual ICollection<BookPublisher>? BookPublishers { get; set; }
    
}
