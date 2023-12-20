using System.ComponentModel.DataAnnotations;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual List<User> UserStatus { get; set; } = null!;
    }
}
