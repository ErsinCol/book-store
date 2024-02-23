using FluentValidation;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().When(command => command.Model.Title != default);
            RuleFor(command => command.Model.GenreId).GreaterThan(0).When(command => command.Model.GenreId != default);
        }
    }
}