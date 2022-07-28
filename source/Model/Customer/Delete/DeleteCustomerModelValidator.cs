using FluentValidation;

namespace AlphaCentauri.Model;

public sealed class DeleteCustomerModelValidator : AbstractValidator<DeleteCustomerModel>
{
    public DeleteCustomerModelValidator()
    {
        RuleFor(model => model.Id).NotEmpty();
    }
}
