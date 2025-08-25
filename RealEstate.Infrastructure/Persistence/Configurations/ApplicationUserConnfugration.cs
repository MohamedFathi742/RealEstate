using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Persistence.Configutations;
public class ApplicationUserConnfugration : IEntityTypeConfiguration<ApplicationUser>
{
   

    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FullName)
              .IsRequired()
              .HasMaxLength(150);

       
    }
}
