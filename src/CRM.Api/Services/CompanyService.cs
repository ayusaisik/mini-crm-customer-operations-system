using CRM.Api.Data;
using CRM.Api.DTOs.Companies;
using CRM.Api.Entities;
using CRM.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Services;

public class CompanyService(CrmDbContext dbContext) : ICompanyService
{
    public async Task<List<CompanyResponseDto>> GetAllAsync()
    {
        var companies = await dbContext.Companies
            .AsNoTracking()
            .ToListAsync();

        return companies.Select(MapToResponseDto).ToList();
    }

    public async Task<CompanyResponseDto?> GetByIdAsync(int id)
    {
        var company = await dbContext.Companies
            .AsNoTracking()
            .FirstOrDefaultAsync(company => company.Id == id);

        return company is null ? null : MapToResponseDto(company);
    }

    public async Task<CompanyResponseDto> CreateAsync(CreateCompanyRequest request)
    {
        var nameExists = await dbContext.Companies
            .AnyAsync(company => company.Name == request.Name);

        if (nameExists)
        {
            throw new InvalidOperationException(
                $"A company with the name '{request.Name}' already exists.");
        }

        var company = new Company
        {
            Name = request.Name,
            Industry = request.Industry,
            Email = request.Email,
            Phone = request.Phone,
            Website = request.Website,
            Address = request.Address,
            CreatedAt = DateTime.UtcNow
        };

        dbContext.Companies.Add(company);
        await dbContext.SaveChangesAsync();

        return MapToResponseDto(company);
    }

    public async Task<CompanyResponseDto?> UpdateAsync(
        int id,
        UpdateCompanyRequest request)
    {
        var company = await dbContext.Companies.FindAsync(id);

        if (company is null)
        {
            return null;
        }

        var nameExists = await dbContext.Companies
            .AnyAsync(existingCompany =>
                existingCompany.Id != id &&
                existingCompany.Name == request.Name);

        if (nameExists)
        {
            throw new InvalidOperationException(
                $"A company with the name '{request.Name}' already exists.");
        }

        company.Name = request.Name;
        company.Industry = request.Industry;
        company.Email = request.Email;
        company.Phone = request.Phone;
        company.Website = request.Website;
        company.Address = request.Address;
        company.UpdatedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();

        return MapToResponseDto(company);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var company = await dbContext.Companies.FindAsync(id);

        if (company is null)
        {
            return false;
        }

        dbContext.Companies.Remove(company);
        await dbContext.SaveChangesAsync();

        return true;
    }

    private static CompanyResponseDto MapToResponseDto(Company company)
    {
        return new CompanyResponseDto
        {
            Id = company.Id,
            Name = company.Name,
            Industry = company.Industry,
            Email = company.Email,
            Phone = company.Phone,
            Website = company.Website,
            Address = company.Address,
            CreatedAt = company.CreatedAt,
            UpdatedAt = company.UpdatedAt
        };
    }
}
