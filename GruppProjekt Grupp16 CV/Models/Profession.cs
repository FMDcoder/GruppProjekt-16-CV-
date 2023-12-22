using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Profession
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Det måste finnas en titel för utbildningen!")]
        [StringLength(100, ErrorMessage = "Titeln på utbildningen får inte vara längre än 100 karaktärer!")]
        public string Title { get; set; } = null!;

        [Range(0, 100, ErrorMessage = "Utbildningen kan inte vara mindre än 0 eller högre än 100!")]
        public int Time { get; set; }

        public virtual List<UserEducation> UserEducations { get; set; } = null!;
    }
}
