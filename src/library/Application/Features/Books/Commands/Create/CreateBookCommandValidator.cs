using FluentValidation;

namespace Application.Features.Books.Commands.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(c => c.ISBN).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Pages).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.Language).NotEmpty();
        RuleFor(c => c.UnitsInStock).NotEmpty();
        
    }
}