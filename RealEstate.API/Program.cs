
using Microsoft.AspNetCore.Identity;
using RealEstate.Infrastructure;
using RealEstate.Infrastructure.Seed;
using System.Threading.Tasks;



namespace RealEstate.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
       // builder.Services.addapplication();
        builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection")!);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope()) 
        {

            var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await DefaultRoles.SeedRolesAsync(roleManger);
        
        }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
