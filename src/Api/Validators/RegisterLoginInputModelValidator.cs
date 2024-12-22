using Api.InputModel;
using FluentValidation;

namespace Api.Validators;

public class RegisterLoginInputModelValidator : AbstractValidator<RegisterLoginInputModel>
{
    public RegisterLoginInputModelValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}
