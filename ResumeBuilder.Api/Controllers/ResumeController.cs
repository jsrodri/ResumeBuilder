using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ResumeBuilder.Data;
using ResumeBuilder.Data.Context;
using ResumeBuilder.DataTransferObjects;
using System.Text;

namespace ResumeBuilder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly ILogger<ResumeController> _logger;

        private readonly ResumeBuilderDbContext _dbContext;

        private readonly IMapper _mapper;
        public ResumeController(ILogger<ResumeController> logger, ResumeBuilderDbContext resumeBuilderDbContext, IMapper mapper)
        {
            _logger = logger;
            _dbContext = resumeBuilderDbContext;
            _mapper = mapper;
        }

        [HttpPost(Name = "ImportResume")]
        public async Task<List<ResumeImportResultDto>> Post([FromForm] params IFormFile[] jsonFiles)
        {
            List<ResumeImportResultDto> result = new List<ResumeImportResultDto>();

            foreach (IFormFile jsonFile in jsonFiles)
            {

                if (jsonFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        jsonFile.CopyTo(ms);
                        var fileBytes = ms.ToArray();

                        string jsonStr = Encoding.UTF8.GetString(fileBytes);
                        ResumeDto? resumeDto = JsonConvert.DeserializeObject<ResumeDto>(jsonStr);

                        if (resumeDto == null || resumeDto?.Contact == null)
                        {
                            resumeDto = new ResumeDto();
                        }

                        Contact contact = new Contact();

                        _mapper.Map(resumeDto.Contact, contact);

                        await _dbContext.Contact.AddAsync(contact);   


                        Resume resume = new Resume { ContactId = contact.Id };
                        resume.FileName = jsonFile.FileName;
                        resume.ProfessionalSummary = resumeDto.ProfessionalSummary;

                        await _dbContext.Resume.AddAsync(resume);

                        List<Skill> skills = new List<Skill>();

                        _mapper.Map(resumeDto.Skills, skills);

                        foreach (Skill skill in skills)
                        {
                            skill.ResumeId = resume.Id;
                            await _dbContext.Skill.AddAsync(skill);
                        }

                        await _dbContext.SaveChangesAsync();


                        result.Add(new ResumeImportResultDto()
                        {
                            ContactId = contact.Id,
                            ResumeId = resume.Id
                        });
                    }
                }
            }
           
            return result;
        }

        [HttpGet]
        [Route("GetResumes")]
        public async Task<List<ResumeDto>> GetResumes()
        {
            List<ResumeDto> result = new List<ResumeDto>();

            var resumes = await _dbContext.Resume
                .Include(r => r.Contact)
                .ToListAsync();

            _mapper.Map(resumes, result);


            return result;
        }

        [HttpGet]
        [Route("GetResumes/{resumeId}")]
        public async Task<ResumeDto> GetResume(int resumeId)
        {
            ResumeDto result = new ResumeDto();

            var resumes = await _dbContext.Resume
                .Where(x => x.Id == resumeId)
                .Include(r => r.Contact)
                .Include(r => r.Skills)
                .FirstOrDefaultAsync();

            _mapper.Map(resumes, result);


            return result;
        }
    }
}