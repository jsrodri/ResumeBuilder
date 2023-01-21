using AutoMapper;
using ResumeBuilder.Data;
using ResumeBuilder.DataTransferObjects;

namespace ResumeBuilder.Api.Profiles
{
    public class ResumeProfile : Profile
    {
        public ResumeProfile()
        {
            CreateMap<Resume, ResumeDto>();
            CreateMap<ResumeDto, Resume>();

        }
    }
}

