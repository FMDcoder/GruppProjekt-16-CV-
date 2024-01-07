using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Job
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(100)]
        public string Title { get; set; } 

        public virtual List<UserExperience> UserExperinces { get; set; } = new List<UserExperience>();
    }
}
