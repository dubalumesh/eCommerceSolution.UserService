using eCommerce.Infrastructure;
using eCommerce.Core;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using eCommerce.API.MiddleWares;
using eCommerce.Core.Entities;
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

        // builder.Services.AddFluentValidationAutoValidation();

        // Add controllers to the service collection
        builder.Services.AddControllers().AddJsonOptions(option =>
        {
            option.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        });

        //Build the web application
        var app = builder.Build();
        app.UseExceptionHandlingMiddleware();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}