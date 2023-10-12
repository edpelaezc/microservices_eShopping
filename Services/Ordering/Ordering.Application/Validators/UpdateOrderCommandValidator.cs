using FluentValidation;
using Ordering.Application.Commands;

namespace Ordering.Application.Validators;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(o => o.OrderDto.UserName)
            .NotEmpty()
            .WithMessage("{UserName} is required")
            .NotNull()
            .MaximumLength(70)
            .WithMessage("{UserName} must not exceed 70 characters");
        RuleFor(o => o.OrderDto.TotalPrice)
            .NotEmpty()
            .WithMessage("{TotalPrice} is required.")
            .GreaterThan(-1)
            .WithMessage("{TotalPrice} should not be -ve.");
        RuleFor(o => o.OrderDto.EmailAddress)
            .NotEmpty()
            .WithMessage("{EmailAddress} is required");
        RuleFor(o => o.OrderDto.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("{FirstName} is required");
        RuleFor(o => o.OrderDto.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage("{LastName} is required");
    }
}