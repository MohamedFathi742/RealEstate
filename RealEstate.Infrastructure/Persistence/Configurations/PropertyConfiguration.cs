using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Persistence.Configutations;
public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Titel)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(p => p.Price)
         .HasColumnType("decimal(18,2)");

        builder.Property(p => p.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        builder.Property(p => p.ImagePath)
        .IsRequired()
        .HasMaxLength(500);


        builder.HasOne(p => p.Owner)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(p => p.OwnerId)
.OnDelete(DeleteBehavior.Cascade);
    }
}
