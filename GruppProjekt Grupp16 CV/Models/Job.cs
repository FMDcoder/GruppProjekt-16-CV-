using System.ComponentModel.DataAnnotations;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Varje jobb måste ha en titel!")]
        [StringLength(100, ErrorMessage = "Titeln på jobbet får inte vara längre än 100 karaktärer!")]
        public string Title { get; set; } = null!;
    }
}
