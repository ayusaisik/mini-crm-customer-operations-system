using CRM.Api.DTOs.Customers;
using CRM.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController(ICustomerService customerService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CustomerResponseDto>>> GetAll()
    {
        var customers = await customerService.GetAllAsync();

        return Ok(customers);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CustomerResponseDto>> GetById(int id)
    {
        var customer = await customerService.GetByIdAsync(id);

        if (customer is null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerResponseDto>> Create(
        CreateCustomerRequest request)
    {
        try
        {
            var customer = await customerService.CreateAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(new { message = exception.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CustomerResponseDto>> Update(
        int id,
        UpdateCustomerRequest request)
    {
        try
        {
            var customer = await customerService.UpdateAsync(id, request);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(new { message = exception.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await customerService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
