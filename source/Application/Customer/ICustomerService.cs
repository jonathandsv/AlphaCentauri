using AlphaCentauri.CrossCutting;
using AlphaCentauri.Model;

namespace AlphaCentauri.Application;

public interface ICustomerService
{
    IResult<long> Add(AddCustomerModel model);

    IResult Delete(DeleteCustomerModel model);

    IEnumerable<CustomerModel> Get();

    CustomerModel Get(long id);

    IResult Update(UpdateCustomerModel model);

    IResult Update(UpdateCustomerNameModel model);
}
