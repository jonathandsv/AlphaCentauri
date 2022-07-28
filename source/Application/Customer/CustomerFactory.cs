using AlphaCentauri.Domain;
using AlphaCentauri.Model;

namespace AlphaCentauri.Application;

public sealed class CustomerFactory : ICustomerFactory
{
    public CustomerModel Create(Customer customer)
    {
        return customer is null ? default : new(customer.Id, customer.Name, customer.Birthday);
    }

    public Customer Create(AddCustomerModel model)
    {
        return model is null ? default : new(default, model.Name, model.Birthday);
    }

    public Customer Create(UpdateCustomerModel model)
    {
        return model is null ? default : new(model.Id, model.Name, model.Birthday);
    }
}
