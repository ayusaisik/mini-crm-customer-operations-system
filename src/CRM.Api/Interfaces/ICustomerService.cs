using CRM.Api.DTOs.Customers;

namespace CRM.Api.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerResponseDto>> GetAllAsync();

    Task<CustomerResponseDto?> GetByIdAsync(int id);

    Task<CustomerResponseDto> CreateAsync(CreateCustomerRequest request);

    Task<CustomerResponseDto?> UpdateAsync(int id, UpdateCustomerRequest request);

    Task<bool> DeleteAsync(int id);
}
