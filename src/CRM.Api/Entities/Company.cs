namespace CRM.Api.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Industry { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Website { get; set; }

    public string? Address { get; set; }
}
