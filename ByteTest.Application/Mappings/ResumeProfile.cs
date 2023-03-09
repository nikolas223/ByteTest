using AutoMapper;
using ByteTest.Application.Commands.Resume.Models;
using ByteTest.Application.Dtos;
using ByteTest.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ByteTest.Application.Mappings;

public class ResumeProfile: Profile
{
    public ResumeProfile()
    {
        CreateMap<CommandProperties, Resume>()
            .ForMember(destination => destination.CvFileName,opt => 
                opt.MapFrom(src => src.Cv != null? src.Cv.FileName: null ))
            .ForMember(destination => destination.CvContentType,opt => 
                opt.MapFrom(src => src.Cv != null? src.Cv.ContentType: null ))
            .ForMember(destination => destination.Cv,opt => 
                opt.MapFrom(src => src.Cv != null? src.Cv.GetBytes().GetAwaiter().GetResult(): null ));

        CreateMap<Resume, CreateUpdateResumeDto>()
            .ForMember(destination => destination.Cv,opt => 
                opt.Ignore());
        
        CreateMap<Resume, CvDto>();
        
        CreateMap<Resume, ResumeDto>()
            .ForMember(destination => destination.Degree,opt => 
            opt.MapFrom(src => src.Degree != null? src.Degree.Name : "" ));
    }
}
public static class FormFileExtensions
{
    public static async Task<byte[]> GetBytes(this IFormFile formFile)
    {
        await using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}