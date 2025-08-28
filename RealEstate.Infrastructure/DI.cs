using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Application;
using RealEstate.Application.Interfaces;
using RealEstate.Application.Interfaces.Security;
using RealEstate.Application.Services;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Persistence;
using RealEstate.Infrastructure.Repositories;
using RealEstate.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure;
public static class DI
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString,IConfiguration configuration )
    {

        services.AddDbContext<ApplicationDbContext>(options =>

        options.UseSqlServer(connectionString)

        );






        services.AddIdentity<ApplicationUser, IdentityRole>()
     .AddEntityFrameworkStores<ApplicationDbContext>()
     .AddDefaultTokenProviders();


        var jwtSettings = configuration.GetSection("JWT");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o => 
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer= jwtSettings["Issuer"],
                ValidAudience= jwtSettings["Audience"],
                IssuerSigningKey=new SymmetricSecurityKey(key)

            };


        });


        services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPropertyService, PropertyService>();

        services.AddScoped<IPropertyRepository,PropertyRepository>();
        services.AddScoped<IJwtService,JwtService>();



        var config = TypeAdapterConfig.GlobalSettings;
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();


        services.AddValidatorsFromAssembly(typeof(DI).Assembly);


        return services;

    }




}
