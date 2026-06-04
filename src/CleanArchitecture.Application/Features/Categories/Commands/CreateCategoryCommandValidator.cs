using FluentValidation;

namespace CleanArchitecture.Application.Features.Categories.Commands;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200);

        RuleForEach(x => x.ProductIds)
            .GreaterThan(0).WithMessage("ProductId must be greater than zero.");
    }
}
