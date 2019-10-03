using Kwaffeur.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            builder.Property(e => e.Address).HasMaxLength(60);
        }
    }
}


