using FluentValidation;

namespace Application.Features.BookMembers.Commands.Delete;

public class DeleteBookMemberCommandValidator : AbstractValidator<DeleteBookMemberCommand>
{
    public DeleteBookMemberCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}