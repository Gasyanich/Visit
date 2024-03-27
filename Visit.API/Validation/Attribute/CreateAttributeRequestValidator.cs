using System.Text.Json;
using FluentValidation;
using Visit.Contracts.Attribute;
using Visit.Contracts.Attribute.Create;

namespace Visit.API.Validation.Attribute;

public class CreateAttributeRequestValidator : AbstractValidator<CreateAttributeRequest>
{
    public CreateAttributeRequestValidator()
    {
        RuleFor(r => r.Name).NotEmpty();

        RuleFor(r => r.Order)
            .NotNull()
            .GreaterThan(0);

        RuleFor(r => r.AllowMultipleValues).NotNull();
        RuleFor(r => r.CanUseInFilter).NotNull();

        RuleFor(r => r.PredefinedValues)
            .Must(values => values.All(je => je.ValueKind == JsonValueKind.String))
            .When(r => r.Type == AttributeType.String);
        
        RuleFor(r => r.PredefinedValues)
            .Must(values => values.All(je => je.ValueKind == JsonValueKind.Number && je.TryGetInt32(out _)))
            .When(r => r.Type == AttributeType.Int);
        
        RuleFor(r => r.PredefinedValues)
            .Must(values => values.All(je => je.ValueKind == JsonValueKind.Number && je.TryGetDouble(out _)))
            .When(r => r.Type == AttributeType.Double);
    }
}