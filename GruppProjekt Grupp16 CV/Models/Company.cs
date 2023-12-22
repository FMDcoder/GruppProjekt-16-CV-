using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Varje företag måste ha ett namn!")]
        [StringLength(100, ErrorMessage = "Namnet på företaget får inte vara längre än 100 karaktärer!")]
        public string Title { get; set; } = null!;

        public virtual List<UserExperince> UserExperinces { get; set; } = null!;
    }
}
