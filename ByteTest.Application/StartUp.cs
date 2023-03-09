using ByteTest.Application.Behaviors;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ByteTest.Application;

public static class StartUp
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
        });
        
        builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    public static void ConfigurePipeline(this WebApplication app)
    {

    }
}