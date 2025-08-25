using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure;
public static class DI
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {

        services.AddDbContext<ApplicationDbContext>(options =>

        options.UseSqlServer(connectionString)

        );

        services.AddIdentity<ApplicationUser, IdentityRole>()
     .AddEntityFrameworkStores<ApplicationDbContext>()
     .AddDefaultTokenProviders();




        return services;

    }




}
