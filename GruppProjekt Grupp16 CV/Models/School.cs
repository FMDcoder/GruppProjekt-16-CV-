using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class School
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),]
        public int Id { get; set; }

        [Required(ErrorMessage = "Varje Skola måste ha ett namn!")]
        [StringLength(100, ErrorMessage = "Skolans namn får inte vara längre än 100 karaktärer!")]
        public string Title { get; set; } 

        public virtual List<UserEducation> UserEducations { get; set; } = new List<UserEducation>(); 
    }
}
