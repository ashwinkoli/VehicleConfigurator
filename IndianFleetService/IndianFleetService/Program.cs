using Microsoft.EntityFrameworkCore;
using VehicleConfigurator.Model;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var b = builder.Configuration.GetConnectionString("Vehicle");
        builder.Services.AddDbContext<VehicleDbContext>((op) => op.UseSqlServer(b));
        builder.Services.AddCors((p) => p.AddDefaultPolicy(policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.UseCors();
        app.Run();
    }
}