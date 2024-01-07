using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class UserEducation
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public int ProfessionId { get; set; }
        public int SchoolId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User UserObject { get; set; }

        [ForeignKey(nameof(ProfessionId))]
        public virtual Profession ProfesssionObject { get; set; }

        [ForeignKey(nameof(SchoolId))]
        public virtual School SchoolObject { get; set; }
    }
}
