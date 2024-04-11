using NArchitecture.Core.Persistence.Repositories;


namespace Domain.Entities;
public class Category : Entity<Guid>
{
    public Category(Guid id, string categoryName):base(id)
    {
        CategoryName = categoryName;
    }
    public Category()
    {

    }

    public string CategoryName { get; set; }

    public ICollection<CategoryBook>? CategoryBooks { get; set; }


}
