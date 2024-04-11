using NArchitecture.Core.Persistence.Repositories;


namespace Domain.Entities;
public class Member : Entity<Guid>
{
    public Member(Guid id, string firstName, string lastName, string email, string phone):base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
    public Member() { }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }    
    public string Phone { get; set; }
    public Guid UserId { get; set; }
    public virtual User? User { get; set; }
    public virtual ICollection<BookMember>? BookMembers { get; set; } = null;

}
