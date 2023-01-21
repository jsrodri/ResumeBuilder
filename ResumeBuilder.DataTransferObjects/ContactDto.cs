using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.DataTransferObjects
{
    public class ContactDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string? Address { get; set; }

        public string? State { get; set; }

        public string? Zip { get; set; }

        public string? Phone { get; set; }

    }
}