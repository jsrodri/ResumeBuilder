using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data;
using ResumeBuilder.Data.Context;
using ResumeBuilder.DataTransferObjects;

namespace ResumeBuilder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;

        private readonly ResumeBuilderDbContext _dbContext;

        private readonly IMapper _mapper;
        public ContactController(ILogger<ContactController> logger, ResumeBuilderDbContext resumeBuilderDbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = resumeBuilderDbContext;
            _mapper = mapper;
        }

        [HttpPost(Name = "ImportContact")]
        public async Task<ContactDto> Post([FromBody]ContactDto contactDto)
        {
            Contact contact = new Contact();
            contact.FirstName = contactDto.FirstName;
            contact.LastName = contactDto.LastName;

            await _dbContext.Contact.AddAsync(contact);

            //foreach (ResumeDto resumeDto in contactDto.Resumes)
            //{
            //    Resume resume = new Resume { ContactId = contact.Id };
            //    await _dbContext.Resume.AddAsync(resume);

            //    foreach (SkillDto skillDto in resumeDto.Skills)
            //    {
            //        Skill skill = new Skill { ResumeId = resume.Id, Description = skillDto.Description };
            //        await _dbContext.Skill.AddAsync(skill);
            //    }
            //}

            await _dbContext.SaveChangesAsync();

            ContactDto result = new ContactDto();
            _mapper.Map(contact, result);
            return result;
        }

        [HttpGet]
        [Route("GetContacts")]
        public async Task<List<ContactDto>> GetContacts(int contactId)
        {
            List<ContactDto> result = new List<ContactDto>();

            //if this was a real product that would support lots of contacts
            //we would need to put server side pagination and filtering in place

            var contact = await _dbContext.Contact
                .OrderBy(contact => contact.FirstName)
                .ThenBy(contact => contact.LastName).ToListAsync();

            _mapper.Map(contact, result);


            return result;
        }

        [HttpGet]
        [Route("GetContacts/{contactId}")]
        public async Task<ContactDto> GetContact(int contactId)
        {
            ContactDto result = new ContactDto();

            var contact = await _dbContext.Contact.Where(c => c.Id == contactId)
                .Include(c => c.Resumes)
                .FirstOrDefaultAsync();

            _mapper.Map(contact, result);


            return result;
        }
    }
}