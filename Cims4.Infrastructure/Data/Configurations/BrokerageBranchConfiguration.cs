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
    public class BrokerageBranchConfiguration : IEntityTypeConfiguration<BrokerageBranch>
    {
        public void Configure(EntityTypeBuilder<BrokerageBranch> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.BranchCode)
                .HasMaxLength(20);

            builder.Property(x => x.Address)
                .HasMaxLength(500);

            builder.Property(x => x.City)
                .HasMaxLength(100);

            builder.Property(x => x.State)
                .HasMaxLength(50);

            builder.Property(x => x.ZipCode)
                .HasMaxLength(20);

            builder.Property(x => x.Phone)
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasMaxLength(200);

            // Relationships
            builder.HasOne(x => x.Brokerage)
                .WithMany(x => x.Branches)
                .HasForeignKey(x => x.BrokerageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
