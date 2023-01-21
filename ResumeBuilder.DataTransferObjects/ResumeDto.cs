using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.DataTransferObjects
{
    public class ResumeDto
    {
        [Required]
        public int Id { get; set; }

        public string? FileName { get; set; }

        public string? ProfessionalSummary { get; set; }

        public DateTimeOffset ImportDateTime {get; set;}
        public ContactDto Contact { get; set; } = new ContactDto();
        public List<SkillDto> Skills
        {
            get;
            set;
        } = new List<SkillDto>();
    }
}