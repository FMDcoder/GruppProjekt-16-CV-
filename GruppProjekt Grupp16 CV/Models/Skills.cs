using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Skills
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } 

        public virtual List<UserSkills> UserSkills { get; set; } = new List<UserSkills>();
    }
}
