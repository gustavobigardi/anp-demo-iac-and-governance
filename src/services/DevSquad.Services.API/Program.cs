using DevSquad.Modules.Infrastructure.IoC;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {

            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "DevSquad API",
                    Version = "v1",
                    Description = "DevSquad APIs",
                    Contact = new OpenApiContact
                    {
                        Name = "DevSquad APIs"
                    }
                });
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        RegisterServices(builder.Services);

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void RegisterServices(IServiceCollection services)
    {
        new RootBootstrapper().BootstrapperRegisterServices(services);
    }
}