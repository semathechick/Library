using FluentValidation;

namespace Application.Features.BookMembers.Commands.Create;

public class CreateBookMemberCommandValidator : AbstractValidator<CreateBookMemberCommand>
{
    public CreateBookMemberCommandValidator()
    {
        RuleFor(c => c.BookId).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
    }
}