using Cims4.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cims4.Infrastructure.Data.Configurations
{
    public class BrokerageConfiguration : IEntityTypeConfiguration<Brokerage>
    {
        public void Configure(EntityTypeBuilder<Brokerage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.TradingAs)
                .HasMaxLength(200);

            builder.Property(x => x.WorkPhone)
                .HasMaxLength(20);

            builder.Property(x => x.MobilePhone)
                .HasMaxLength(20);

            builder.Property(x => x.Email)
                .HasMaxLength(150);

            builder.Property(x => x.Fax)
                .HasMaxLength(20);

            builder.Property(x => x.RegistrationNumber)
                .HasMaxLength(50);

            builder.Property(x => x.VatNumber)
                .HasMaxLength(50);

            builder.Property(x => x.IncomeTaxNumber)
                .HasMaxLength(50);

            builder.Property(x => x.Website)
                .HasMaxLength(500);

            // Relationships
            builder.HasMany(x => x.Branches)
                .WithOne(x => x.Brokerage)
                .HasForeignKey(x => x.BrokerageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
