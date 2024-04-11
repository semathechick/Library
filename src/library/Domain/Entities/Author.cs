using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Author : Entity<Guid>
{
    public Author(Guid id, string name, string surName):base(id)
    {
        Name = name;
        SurName = surName;
        
    }
    public Author()
    {

    }

    public string Name { get; set; }
    public string SurName { get; set; }
    public ICollection<AuthorBook> AuthorBooks { get; set; }

}
