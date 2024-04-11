using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;


namespace Domain.Entities;
public class Book : Entity<Guid>
{
    public Book(Guid id, string ıSBN, string name, int pages, string? language, int unitsInStock):base(id)
    {
        ISBN = ıSBN;
        Name = name;
        Pages = pages;
        
        Language = language;
        UnitsInStock = unitsInStock;
       
        
        
    }
    public Book() { }

    public string ISBN { get; set; }
    public string Name { get; set; }
    public int Pages { get; set; }
    public BookStatus? Status { get; set; }
    public string? Language { get; set; }
    public int UnitsInStock { get; set; }
    
    

    public virtual ICollection<AuthorBook>? AuthorBooks { get; set; }
    
    public virtual ICollection<BookMember>? BookMembers { get; set; }
    
    public virtual ICollection<CategoryBook>? CategoryBooks { get; set; }

}
