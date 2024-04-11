using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BookMember : Entity<Guid>
{
    public BookMember(Guid id,Guid bookId, Guid memberId):base(id)
    {
        
        BookId = bookId;
        MemberId = memberId;
    }
    public BookMember() { }
    public virtual Book? Book { get; set; }
    public Guid BookId { get; set; }
    public virtual Member? Member { get; set; }
    public Guid MemberId { get; set; }
    
    
}