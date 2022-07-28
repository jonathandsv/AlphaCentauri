using FluentValidation;

namespace AlphaCentauri.Model;

public sealed class UpdateCustomerNameModelValidator : AbstractValidator<UpdateCustomerNameModel>
{
    public UpdateCustomerNameModelValidator()
    {
        RuleFor(model => model.Id).NotEmpty();
        RuleFor(model => model.Name).NotEmpty();
    }
}
