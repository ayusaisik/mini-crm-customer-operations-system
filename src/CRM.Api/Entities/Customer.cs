namespace CRM.Api.Entities;

public class Customer : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public CustomerStatus Status { get; set; } = CustomerStatus.Lead;
}
