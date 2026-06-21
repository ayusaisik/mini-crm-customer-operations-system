using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Data;

public class CrmDbContext(DbContextOptions<CrmDbContext> options) : DbContext(options)
{
}
