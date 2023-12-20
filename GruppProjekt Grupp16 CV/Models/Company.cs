using System.ComponentModel.DataAnnotations;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Varje företag måste ha ett namn!")]
        [StringLength(100, ErrorMessage = "Namnet på företaget får inte vara längre än 100 karaktärer!")]
        public string Title { get; set; } = null!;

        public virtual List<UserExperince> UserExperinces { get; set; } = null!;
    }
}
