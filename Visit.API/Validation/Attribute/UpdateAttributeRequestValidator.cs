using System.Text.Json;
using FluentValidation;
using Visit.Contracts.Attribute;

namespace Visit.API.Validation.Attribute;

public class UpdateAttributeRequestValidator : AbstractValidator<UpdateAttributeRequest>
{
    public UpdateAttributeRequestValidator()
    {
        RuleFor(r => r.Id).GreaterThan(0);
        RuleFor(r => r.Name).NotEmpty().MaximumLength(255);
        RuleFor(r => r.Code).NotEmpty().MaximumLength(255);

        RuleFor(r => r.Order)
            .NotNull()
            .GreaterThan(0);

        RuleFor(r => r.AllowMultipleValues).NotNull();
        
        RuleFor(r => r.IsRequired).NotNull();
        
        RuleFor(r => r.IsUseValuesForTextSearch).NotNull();

        RuleFor(r => r.CanUseInFilter).NotNull();
        
        RuleFor(r => r.PredefinedValues)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(values => values.All(je => je.ValueKind == JsonValueKind.String))
            .When(r => r.Type == AttributeType.String)
            .Must(values => values.All(je => je.ValueKind == JsonValueKind.Number && je.TryGetInt32(out _)))
            .When(r => r.Type == AttributeType.Int);
    }
}