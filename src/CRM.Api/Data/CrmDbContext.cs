using CRM.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Data;

public class CrmDbContext(DbContextOptions<CrmDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customers");

            entity.Property(customer => customer.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(customer => customer.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(customer => customer.Email)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(customer => customer.Phone)
                .HasMaxLength(30);

            entity.Property(customer => customer.Status)
                .HasConversion<string>()
                .IsRequired();

            entity.Property(customer => customer.CreatedAt)
                .IsRequired();

            entity.Property(customer => customer.UpdatedAt)
                .IsRequired(false);

            entity.HasIndex(customer => customer.Email)
                .IsUnique();
        });
    }
}
