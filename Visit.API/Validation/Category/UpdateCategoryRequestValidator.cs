using FluentValidation;
using Visit.Contracts.Category;

namespace Visit.API.Validation.Category;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryRequestValidator()
    {
        RuleFor(r => r.Id).GreaterThan(0);
        
        RuleFor(r => r.Name).NotEmpty().MaximumLength(255);
    }
}