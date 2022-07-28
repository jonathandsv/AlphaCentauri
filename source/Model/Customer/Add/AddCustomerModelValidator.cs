using FluentValidation;

namespace AlphaCentauri.Model;

public sealed class AddCustomerModelValidator : AbstractValidator<AddCustomerModel>
{
    public AddCustomerModelValidator()
    {
        RuleFor(model => model.Name).NotEmpty();
        RuleFor(model => model.Birthday).Birthday();
    }
}
