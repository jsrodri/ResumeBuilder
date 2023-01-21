using AutoMapper;
using ResumeBuilder.Data;
using ResumeBuilder.DataTransferObjects;

namespace ResumeBuilder.Api.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillDto, Skill>();
        }
    }
}
