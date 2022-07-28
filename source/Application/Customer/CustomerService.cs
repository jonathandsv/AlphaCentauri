using AlphaCentauri.CrossCutting;
using AlphaCentauri.Database;
using AlphaCentauri.Model;

namespace AlphaCentauri.Application;

public sealed class CustomerService : ICustomerService
{
    private readonly ICustomerFactory _customerFactory;
    private readonly ICustomerRepository _customerRepository;

    public CustomerService
    (
        ICustomerFactory customerFactory,
        ICustomerRepository customerRepository
    )
    {
        _customerFactory = customerFactory;
        _customerRepository = customerRepository;
    }

    public IResult<long> Add(AddCustomerModel model)
    {
        var validation = new AddCustomerModelValidator().Validate(model);

        if (!validation.IsValid) return Result<long>.Fail(validation.ToString());

        var customer = _customerFactory.Create(model);

        var id = _customerRepository.Add(customer);

        return Result<long>.Success(id);
    }

    public IResult Delete(DeleteCustomerModel model)
    {
        var validation = new DeleteCustomerModelValidator().Validate(model);

        if (!validation.IsValid) return Result.Fail(validation.ToString());

        _customerRepository.Delete(model.Id);

        return Result.Success();
    }

    public IEnumerable<CustomerModel> Get()
    {
        return _customerRepository.Get().Select(_customerFactory.Create);
    }

    public CustomerModel Get(long id)
    {
        var customer = _customerRepository.Get(id);

        return _customerFactory.Create(customer);
    }

    public IResult Update(UpdateCustomerModel model)
    {
        var validation = new UpdateCustomerModelValidator().Validate(model);

        if (!validation.IsValid) return Result.Fail(validation.ToString());

        var customer = _customerFactory.Create(model);

        _customerRepository.Update(customer);

        return Result.Success();
    }

    public IResult Update(UpdateCustomerNameModel model)
    {
        var validation = new UpdateCustomerNameModelValidator().Validate(model);

        if (!validation.IsValid) return Result.Fail(validation.ToString());

        var customer = _customerRepository.Get(model.Id);

        customer.UpdateName(model.Name);

        _customerRepository.Update(customer);

        return Result.Success();
    }
}
