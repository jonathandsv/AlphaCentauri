using AlphaCentauri.Domain;
using AlphaCentauri.Model;

namespace AlphaCentauri.Application;

public interface ICustomerFactory
{
    CustomerModel Create(Customer customer);

    Customer Create(AddCustomerModel model);

    Customer Create(UpdateCustomerModel model);
}
