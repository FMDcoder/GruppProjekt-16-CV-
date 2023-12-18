using System.ComponentModel.DataAnnotations;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Titel { get; set; } = null!;
    }
}
