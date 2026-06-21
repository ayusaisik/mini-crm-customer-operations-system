using CRM.Api.Data;
using CRM.Api.DTOs.Customers;
using CRM.Api.Entities;
using CRM.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Services;

public class CustomerService(CrmDbContext dbContext) : ICustomerService
{
    public async Task<List<CustomerResponseDto>> GetAllAsync()
    {
        var customers = await dbContext.Customers
            .AsNoTracking()
            .ToListAsync();

        return customers.Select(MapToResponseDto).ToList();
    }

    public async Task<CustomerResponseDto?> GetByIdAsync(int id)
    {
        var customer = await dbContext.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(customer => customer.Id == id);

        return customer is null ? null : MapToResponseDto(customer);
    }

    public async Task<CustomerResponseDto> CreateAsync(CreateCustomerRequest request)
    {
        var emailExists = await dbContext.Customers
            .AnyAsync(customer => customer.Email == request.Email);

        if (emailExists)
        {
            throw new InvalidOperationException(
                $"A customer with the email '{request.Email}' already exists.");
        }

        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            Status = request.Status,
            CreatedAt = DateTime.UtcNow
        };

        dbContext.Customers.Add(customer);
        await dbContext.SaveChangesAsync();

        return MapToResponseDto(customer);
    }

    public async Task<CustomerResponseDto?> UpdateAsync(
        int id,
        UpdateCustomerRequest request)
    {
        var customer = await dbContext.Customers.FindAsync(id);

        if (customer is null)
        {
            return null;
        }

        var emailExists = await dbContext.Customers
            .AnyAsync(existingCustomer =>
                existingCustomer.Id != id &&
                existingCustomer.Email == request.Email);

        if (emailExists)
        {
            throw new InvalidOperationException(
                $"A customer with the email '{request.Email}' already exists.");
        }

        customer.FirstName = request.FirstName;
        customer.LastName = request.LastName;
        customer.Email = request.Email;
        customer.Phone = request.Phone;
        customer.Status = request.Status;
        customer.UpdatedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();

        return MapToResponseDto(customer);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var customer = await dbContext.Customers.FindAsync(id);

        if (customer is null)
        {
            return false;
        }

        dbContext.Customers.Remove(customer);
        await dbContext.SaveChangesAsync();

        return true;
    }

    private static CustomerResponseDto MapToResponseDto(Customer customer)
    {
        return new CustomerResponseDto
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            FullName = $"{customer.FirstName} {customer.LastName}",
            Email = customer.Email,
            Phone = customer.Phone,
            Status = customer.Status.ToString(),
            CreatedAt = customer.CreatedAt,
            UpdatedAt = customer.UpdatedAt
        };
    }
}
