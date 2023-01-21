using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.DataTransferObjects
{
    public class ResumeIdsDto
    {
        [Required]
        public int Id { get; set; }

        public DateTimeOffset ImportDateTime { get; set; } = DateTimeOffset.Now;
    }
}