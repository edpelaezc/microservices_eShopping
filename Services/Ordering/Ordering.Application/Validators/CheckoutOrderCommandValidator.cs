using FluentValidation;
using Ordering.Application.Commands;

namespace Ordering.Application.Validators;

public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidator()
    {
        RuleFor(o => o.OrderForCreationDto.UserName)
            .NotEmpty()
            .WithMessage("{UserName} is required")
            .NotNull()
            .MaximumLength(70)
            .WithMessage("{UserName} must not exceed 70 characters");
        RuleFor(o => o.OrderForCreationDto.TotalPrice)
            .NotEmpty()
            .WithMessage("{TotalPrice} is required.")
            .GreaterThan(-1)
            .WithMessage("{TotalPrice} should not be -ve.");
        RuleFor(o => o.OrderForCreationDto.EmailAddress)
            .NotEmpty()
            .WithMessage("{EmailAddress} is required");
        RuleFor(o => o.OrderForCreationDto.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("{FirstName} is required");
        RuleFor(o => o.OrderForCreationDto.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage("{LastName} is required");
    }   
}