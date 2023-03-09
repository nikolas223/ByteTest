using AutoMapper;
using ByteTest.Application.Commands.Degree.Models;
using ByteTest.Application.Dtos;
using ByteTest.Domain.Entities;

namespace ByteTest.Application.Mappings;

public class DegreeProfile: Profile
{
    public DegreeProfile()
    {
        CreateMap<CommandProperties, Degree>();
        
        CreateMap<Degree, DegreeDto>();
        
        CreateMap<Degree, CreateUpdateDegreeDto>();
    }
}