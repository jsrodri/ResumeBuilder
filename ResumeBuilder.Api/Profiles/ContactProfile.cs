using AutoMapper;
using ResumeBuilder.Data;
using ResumeBuilder.DataTransferObjects;

namespace ResumeBuilder.Api.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDto, Contact>();
        }
    }
}