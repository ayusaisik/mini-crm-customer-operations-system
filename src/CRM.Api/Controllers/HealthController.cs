using CRM.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController(CrmDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "Healthy",
            application = "Mini CRM API",
            timestamp = DateTime.UtcNow
        });
    }

    [HttpGet("database")]
    public async Task<IActionResult> GetDatabaseHealth()
    {
        var canConnect = await dbContext.Database.CanConnectAsync();

        if (canConnect)
        {
            return Ok(new
            {
                status = "Healthy",
                database = "PostgreSQL",
                timestamp = DateTime.UtcNow
            });
        }

        return StatusCode(StatusCodes.Status503ServiceUnavailable, new
        {
            status = "Unhealthy",
            database = "PostgreSQL",
            timestamp = DateTime.UtcNow
        });
    }
}
