using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.Data
{
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Resume")]
        public int ResumeId { get; set; }

        public string Description { get; set; }
        public virtual Resume Resume { get; set; }
    }

}