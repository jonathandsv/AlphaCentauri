using AlphaCentauri.Application;
using AlphaCentauri.Database;
using AlphaCentauri.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AlphaCentauri.Api.Tests;

public class CustomerControllerTest
{
    private static CustomerController CustomerController
    {
        get
        {
            var services = new ServiceCollection();

            services.AddDbContext<Context>(options => options.UseInMemoryDatabase(nameof(Context)));

            services.Scan(scan => scan.FromAssemblies(typeof(ICustomerService).Assembly, typeof(ICustomerRepository).Assembly).AddClasses().AsMatchingInterface());

            services.AddScoped<CustomerController, CustomerController>();

            services.BuildServiceProvider().GetRequiredService<Context>().Database.EnsureDeleted();

            return services.BuildServiceProvider().GetRequiredService<CustomerController>();
        }
    }

    [Fact]
    public void AddShouldReturnBadRequest()
    {
        var model = new AddCustomerModel(string.Empty, DateTime.MaxValue);

        var result = CustomerController.Add(model) as BadRequestObjectResult;

        Assert.IsType<BadRequestObjectResult>(result);

        Assert.NotNull(result.Value);
    }

    [Fact]
    public void AddShouldReturnOk()
    {
        var model = new AddCustomerModel("Name", DateTime.UtcNow);

        var result = CustomerController.Add(model) as OkObjectResult;

        Assert.IsType<OkObjectResult>(result);

        Assert.Equal(1L, Convert.ToInt64(result.Value));
    }

    [Fact]
    public void DeleteShouldReturnBadRequest()
    {
        var result = CustomerController.Delete(default) as BadRequestObjectResult;

        Assert.IsType<BadRequestObjectResult>(result);

        Assert.NotNull(result.Value);
    }

    [Fact]
    public void DeleteShouldReturnOk()
    {
        var result = CustomerController.Delete(1) as OkResult;

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void GetByIdShouldReturnNoContent()
    {
        var result = CustomerController.Get(default) as NoContentResult;

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void GetByIdShouldReturnOk()
    {
        var customerController = CustomerController;

        var model = new AddCustomerModel("Name", DateTime.UtcNow);

        customerController.Add(model);

        var result = customerController.Get(1L) as OkObjectResult;

        Assert.IsType<OkObjectResult>(result);

        Assert.NotNull(result.Value);
    }

    [Fact]
    public void GetShouldReturnNoContent()
    {
        var result = CustomerController.Get() as NoContentResult;

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void GetShouldReturnOk()
    {
        var customerController = CustomerController;

        customerController.Add(new AddCustomerModel("Name", DateTime.UtcNow));

        var result = customerController.Get() as OkObjectResult;

        Assert.IsType<OkObjectResult>(result);

        Assert.True((result.Value as IEnumerable<CustomerModel>)!.Any());
    }

    [Fact]
    public void UpdateNameShouldReturnOk()
    {
        var customerController = CustomerController;

        customerController.Add(new AddCustomerModel("Name", new DateTime(2000, 1, 1)));

        var addedCustomer = (customerController.Get(1L) as OkObjectResult)!.Value as CustomerModel;

        customerController.UpdateName(1L, new UpdateCustomerNameModel { Id = 1L, Name = "Updated" });

        var updatedCustomer = (customerController.Get(1L) as OkObjectResult)!.Value as CustomerModel;

        Assert.NotNull(addedCustomer);

        Assert.NotNull(updatedCustomer);

        Assert.NotEqual(addedCustomer.Name, updatedCustomer.Name);

        Assert.Equal(addedCustomer.Birthday, updatedCustomer.Birthday);
    }

    [Fact]
    public void UpdateShouldReturnOk()
    {
        var customerController = CustomerController;

        customerController.Add(new AddCustomerModel("Name", new DateTime(2000, 1, 1)));

        var addedCustomer = (customerController.Get(1L) as OkObjectResult)!.Value as CustomerModel;

        customerController.Update(1L, new UpdateCustomerModel { Id = 1L, Name = "Updated", Birthday = new DateTime(2000, 2, 2) });

        var updatedCustomer = (customerController.Get(1L) as OkObjectResult)!.Value as CustomerModel;

        Assert.NotNull(addedCustomer);

        Assert.NotNull(updatedCustomer);

        Assert.NotEqual(addedCustomer.Name, updatedCustomer.Name);

        Assert.NotEqual(addedCustomer.Birthday, updatedCustomer.Birthday);
    }
}
