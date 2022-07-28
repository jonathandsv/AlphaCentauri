using FluentValidation;

namespace AlphaCentauri.Model;

public sealed class UpdateCustomerModelValidator : AbstractValidator<UpdateCustomerModel>
{
    public UpdateCustomerModelValidator()
    {
        RuleFor(model => model.Id).NotEmpty();
        RuleFor(model => model.Name).NotEmpty();
        RuleFor(model => model.Birthday).Birthday();
    }
}
