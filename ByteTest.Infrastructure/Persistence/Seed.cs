using ByteTest.Domain.Entities;
using ByteTest.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ByteTest.Infrastructure.Persistence;

public static class Seed
{
    public static async Task InitDb(this WebApplication host)
    {
        using var scope = host.Services.CreateScope();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        #region Test Resumes

        var resumes = new List<Resume>
        {
            new()
            {
                Id = 1,
                FirstName = "Kostas",
                LastName = "Papapauloy",
                Email = "kostas@gmail.com",
                Mobile = "6978963254",
                DegreeId = 2
            },
            new()
            {
                Id = 2,
                FirstName = "Manolis",
                LastName = "Kanelopoulos",
                Email = "manolis@gmail.com",
                Mobile = "6973216547",
                DegreeId = 3
            },
        };
        unitOfWork.ResumesRepository.AddRange(resumes);
        await unitOfWork.SaveChangesAsync();

        #endregion

        #region Test Degrees

        var degrees = new List<Degree>
        {
            new()
            {
                Id = 1,
                Name = "Bsc"
            },
            new()
            {

                Id = 2,
                Name = "Msc"
            },
            new()
            {

                Id = 3,
                Name = "PhD"
            }
        };

        unitOfWork.DegreesRepository.AddRange(degrees);
        await unitOfWork.SaveChangesAsync();

        #endregion
    }
}