using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class UserEducation
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int ProfessionId { get; set; }

        [Key, Column(Order = 2)]
        public int SchoolId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User UserObject { get; set; }

        [ForeignKey(nameof(ProfessionId))]
        public virtual Profession ProfesssionObject { get; set; }

        [ForeignKey(nameof(SchoolId))]
        public virtual School SchoolObject { get; set; }
    }
}
