using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Active).IsRequired(true).HasDefaultValue(true);

            builder.OwnsOne(m => m.Person, a =>
            {
                a.Property(p => p.FirstName).HasMaxLength(150).IsRequired().HasColumnName("FirstName");
                a.Property(p => p.LastName).HasMaxLength(150).IsRequired().HasColumnName("LastName");
                a.Property(p => p.GenderType).IsRequired(true)
                .HasDefaultValue(GenderType.Male).HasColumnName("GenderType");
                a.Ignore(p => p.FullName);
            });

            //GenderType
            builder.Property(e => e.CustomerType)
                      .HasMaxLength(1)
                      .IsRequired()
                      .HasConversion(
                          v => v.ToString(),
                          v => (CustomerType)Enum.Parse(typeof(CustomerType), v))
                          .IsUnicode(false);

            builder.OwnsOne(m => m.Address, a =>
            {
                a.Property(p => p.Street).HasMaxLength(200).HasColumnName("Street");
                a.Property(p => p.Number).HasMaxLength(20).HasColumnName("StreetNumber");
                a.Property(p => p.City).HasMaxLength(200).HasColumnName("City");
                a.Property(p => p.State).HasMaxLength(100).HasColumnName("State");
                a.Property(p => p.ZipCode).HasMaxLength(30).HasColumnName("Zip");
                //country
                a.Property(p => p.Country).HasMaxLength(200).HasColumnName("Country");
            });

            builder.OwnsOne(m => m.ContactData, a =>
            {
                a.Property(p => p.Email).HasMaxLength(200).HasColumnName("Email");
                a.Property(p => p.VatNumber).HasMaxLength(30).HasColumnName("VatNumber");
                a.Property(p => p.Mobile).HasMaxLength(30).HasColumnName("Mobile");
                a.Property(p => p.Phone).HasMaxLength(30).HasColumnName("Phone");
                a.Property(p => p.Fax).HasMaxLength(30).HasColumnName("Fax");
            });

            builder.Property(e => e.Created).IsRequired();
            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.LastModified);
            builder.Property(e => e.LastModifiedBy);
        }
    }
}
