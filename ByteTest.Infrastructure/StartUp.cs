using ByteTest.Domain.Entities;
using ByteTest.Domain.Interfaces;
using ByteTest.Infrastructure.Persistence;
using ByteTest.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ByteTest.Infrastructure;

public static class StartUp
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        // Persistence
        builder.Services.AddDbContext<ByteTestDbContext>(opt => opt.UseInMemoryDatabase("ByteTestDb"));
        
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IGenericRepository<Degree>, DegreesRepository>();
        builder.Services.AddScoped<IGenericRepository<Resume>, ResumesRepository>();
    }

    public static void ConfigurePipeline(this WebApplication app)
    {
        app.InitDb().GetAwaiter().GetResult();
    }
}