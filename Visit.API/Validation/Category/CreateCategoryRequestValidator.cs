using FluentValidation;
using Visit.Contracts.Category;

namespace Visit.API.Validation.Category;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(r => r.Name).NotEmpty().MaximumLength(255);
    }
}