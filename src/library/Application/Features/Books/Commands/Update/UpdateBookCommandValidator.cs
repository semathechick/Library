using FluentValidation;

namespace Application.Features.Books.Commands.Update;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ISBN).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Pages).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.Language).NotEmpty();
        RuleFor(c => c.UnitsInStock).NotEmpty();
        RuleFor(c => c.PublisherId).NotEmpty();
    }
}