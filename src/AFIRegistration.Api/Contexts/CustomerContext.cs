using AFIRegistration.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AFIRegistration.Api.Contexts
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
           // Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(x => 
            {
                x.Property(p => p.Email)
                    .HasConversion(p => p.Value, p => Email.Create(p).Value);
                x.Property(p => p.DateOfBirth)
                    .HasConversion(p => p.Value, p => CustomerDateOfBirth.Create(p).Value);
                x.Property(p => p.PolicyReferenceNumber)
                    .HasConversion(p => p.Value, p => PolicyReferenceNumber.Create(p).Value);
                x.Property(p => p.FirstName)
                    .HasConversion(p => p.Value, p => CustomerFirstName.Create(p).Value);
                x.Property(p => p.LastName)
                    .HasConversion(p => p.Value, p => CustomerLastName.Create(p).Value);
            });
        
        }
    }
}
