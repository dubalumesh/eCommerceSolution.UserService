using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using UserService.API.MiddleWares;
using UserService.Core;
using UserService.Core.Entities;
using UserService.Infrastructure;
//using FluentValidation.AspNetCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddCore(builder.Configuration);
        // Add AutoMapper to the service collection
        builder.Services.AddAutoMapper(typeof(ApplicationUser).Assembly);

        // Adding Cors support

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        // builder.Services.AddFluentValidationAutoValidation();

        // Add controllers to the service collection and Enum serilizer
        builder.Services.AddControllers().AddJsonOptions(option =>
        {
            option.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //Build the web application
        var app = builder.Build();
        app.UseExceptionHandlingMiddleware();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        // Swagger Middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;


            });

        }

        app.MapControllers();

        app.Run();
    }
}