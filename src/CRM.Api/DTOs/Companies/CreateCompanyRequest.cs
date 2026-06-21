namespace CRM.Api.DTOs.Companies;

public class CreateCompanyRequest
{
    public string Name { get; set; } = string.Empty;

    public string? Industry { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }

    public string? Address { get; set; }
}
