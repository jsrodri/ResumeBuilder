using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.Data
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }
        public string? State { get; set; }

        public string? Zip { get; set; }

        public string? Phone { get; set; }
        public ICollection<Resume> Resumes { get; set;} = new HashSet<Resume>();
    }
}