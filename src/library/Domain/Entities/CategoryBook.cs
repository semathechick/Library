using NArchitecture.Core.Persistence.Repositories;


namespace Domain.Entities;
public class CategoryBook : Entity<Guid>
{
    public CategoryBook(Guid id , Guid bookId,Guid categoryId):base(id)
    {
        
        BookId = bookId;
        CategoryId = categoryId;
    }
    public CategoryBook()
    {

    }

    public virtual Book? Book { get; set; }
    public Guid BookId { get; set; }
    public virtual Category? Category { get; set; }
    public Guid CategoryId { get; set; }

}
