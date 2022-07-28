using AlphaCentauri.Domain;

namespace AlphaCentauri.Database;

public interface ICustomerRepository
{
    long Add(Customer customer);

    void Delete(long id);

    IEnumerable<Customer> Get();

    Customer Get(long id);

    void Update(Customer customer);
}
