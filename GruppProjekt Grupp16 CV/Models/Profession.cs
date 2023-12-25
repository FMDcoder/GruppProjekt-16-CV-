using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Profession
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } 

        [Range(0, 100)]
        public int Time { get; set; }

        public virtual List<UserEducation> UserEducations { get; set; } = new List<UserEducation>();
    }
}
