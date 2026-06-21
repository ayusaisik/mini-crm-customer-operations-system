using CRM.Api.DTOs.Companies;
using CRM.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers;

[ApiController]
[Route("api/companies")]
public class CompaniesController(ICompanyService companyService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CompanyResponseDto>>> GetAll()
    {
        var companies = await companyService.GetAllAsync();

        return Ok(companies);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CompanyResponseDto>> GetById(int id)
    {
        var company = await companyService.GetByIdAsync(id);

        if (company is null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    [HttpPost]
    public async Task<ActionResult<CompanyResponseDto>> Create(
        CreateCompanyRequest request)
    {
        try
        {
            var company = await companyService.CreateAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = company.Id }, company);
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(new { message = exception.Message });
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CompanyResponseDto>> Update(
        int id,
        UpdateCompanyRequest request)
    {
        try
        {
            var company = await companyService.UpdateAsync(id, request);

            if (company is null)
            {
                return NotFound();
            }

            return Ok(company);
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(new { message = exception.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await companyService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
