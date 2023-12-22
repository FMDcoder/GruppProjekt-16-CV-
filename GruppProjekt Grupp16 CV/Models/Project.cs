using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Projektet måste ha ett namn!")]
        [StringLength(100, ErrorMessage = "Projektets Titel får inte vara längre än 100 karaktärer!")]
        public string Title { get; set; } = null!;

        [StringLength(1000, ErrorMessage = "Projektets beskrivning får inte vara längre än 1000 karaktärer!")]
        public string? Description { get; set; }

        public virtual List<UserProject> UserProject { get; set; } = null!;
    }
}
