using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            //GenderType
            builder.Property(e => e.GenderType)
                      .HasMaxLength(1)
                      .IsRequired()
                      .HasConversion(
                          v => v.ToString(),
                          v => (GenderType)Enum.Parse(typeof(GenderType), v))
                          .IsUnicode(false);

            builder.Property(e => e.Created).IsRequired();
            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.LastModified);
            builder.Property(e => e.LastModifiedBy);

            builder.OwnsOne(m => m.Name).ToTable("Names");
            //NAME
            builder.OwnsOne(m => m.Name, a =>
            {
                a.Property(p => p.FirstName).HasMaxLength(150).IsRequired();
                a.Property(p => p.LastName).HasMaxLength(150).IsRequired();
                a.Ignore(p => p.FullName);
            });


        }
    }
}
