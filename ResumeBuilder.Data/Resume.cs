using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.Data
{
    public class Resume
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? ProfessionalSummary { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        public string? FileName { get; set; }

        public DateTimeOffset ImportDateTime { get; set; } = DateTimeOffset.Now;

        public virtual Contact Contact { get; set; }

        

        public virtual ICollection<Skill> Skills
        {
            get;
            set;
        } = new HashSet<Skill>();


    }
}