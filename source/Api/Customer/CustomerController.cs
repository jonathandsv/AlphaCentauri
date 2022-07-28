using AlphaCentauri.Application;
using AlphaCentauri.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AlphaCentauri.Api;

[ApiController]
[Route("customers")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public IActionResult Add(AddCustomerModel model)
    {
        return _customerService.Add(model).PostActionResult();
    }

    [HttpDelete("{id:long}")]
    public IActionResult Delete(long id)
    {
        return _customerService.Delete(new DeleteCustomerModel(id)).DeleteActionResult();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get()
    {
        return _customerService.Get().GetActionResult();
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get(long id)
    {
        return _customerService.Get(id).GetActionResult();
    }

    [HttpPut("{id:long}")]
    public IActionResult Update(long id, UpdateCustomerModel model)
    {
        model.Id = id;

        return _customerService.Update(model).PutActionResult();
    }

    [HttpPatch("{id:long}")]
    public IActionResult UpdateName(long id, UpdateCustomerNameModel model)
    {
        model.Id = id;

        return _customerService.Update(model).PatchActionResult();
    }
}
