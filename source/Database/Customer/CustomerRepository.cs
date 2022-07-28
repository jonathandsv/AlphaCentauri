using AlphaCentauri.Domain;
using Microsoft.EntityFrameworkCore;

namespace AlphaCentauri.Database;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly Context _context;

    public CustomerRepository(Context context)
    {
        _context = context;
    }

    public long Add(Customer customer)
    {
        _context.Add(customer);

        _context.SaveChanges();

        return customer.Id;
    }

    public void Delete(long id)
    {
        var customer = Get(id);

        if (customer is null) return;

        _context.Remove(customer);

        _context.SaveChanges();
    }

    public IEnumerable<Customer> Get()
    {
        return _context.Customers;
    }

    public Customer Get(long id)
    {
        return _context.Customers.SingleOrDefault(customer => customer.Id == id);
    }

    public void Update(Customer customer)
    {
        var databaseCustomer = _context.Customers.Find(customer.Id);

        if (databaseCustomer is null) return;

        _context.Entry(databaseCustomer).State = EntityState.Detached;

        _context.Update(customer);

        _context.SaveChanges();
    }
}
