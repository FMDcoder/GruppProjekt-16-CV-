using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Status
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),]
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual List<User> UserStatus { get; set; } = new List<User>();
    }
}
