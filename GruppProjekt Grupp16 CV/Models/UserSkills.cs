using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class UserSkills
    {
		[Key]
		public int Id { get; set; }

		public string UserId { get; set; }

        public int SkillsId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User UserObject { get; set; }

        [ForeignKey(nameof(SkillsId))]
        public virtual Skills SkillsObject { get; set; }
    }
}
