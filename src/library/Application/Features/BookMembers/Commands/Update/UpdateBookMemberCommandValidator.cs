using FluentValidation;

namespace Application.Features.BookMembers.Commands.Update;

public class UpdateBookMemberCommandValidator : AbstractValidator<UpdateBookMemberCommand>
{
    public UpdateBookMemberCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BookId).NotEmpty();
        RuleFor(c => c.MemberId).NotEmpty();
    }
}