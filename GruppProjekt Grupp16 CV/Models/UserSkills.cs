using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class UserSkills
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int SkillsId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User UserObject { get; set; } = null!;

        [ForeignKey(nameof(SkillsId))]
        public virtual Skills SkillsObject { get; set; } = null!;
    }
}
