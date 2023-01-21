using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.DataTransferObjects
{
    public class ResumeImportResultDto
    {
        [Required]
        public int ContactId { get; set; }

        [Required]
        public int ResumeId { get; set; }

    }
}