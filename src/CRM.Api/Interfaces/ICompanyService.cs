using CRM.Api.DTOs.Companies;

namespace CRM.Api.Interfaces;

public interface ICompanyService
{
    Task<List<CompanyResponseDto>> GetAllAsync();

    Task<CompanyResponseDto?> GetByIdAsync(int id);

    Task<CompanyResponseDto> CreateAsync(CreateCompanyRequest request);

    Task<CompanyResponseDto?> UpdateAsync(int id, UpdateCompanyRequest request);

    Task<bool> DeleteAsync(int id);
}
