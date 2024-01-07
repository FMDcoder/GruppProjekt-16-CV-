using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class UserExperince
    {
		[Key]
		public int Id { get; set; }

        public string UserId { get; set; }

        public int JobId { get; set; }

        public int CompanyId { get; set; }

        public int TotalTime { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User UserObject { get; set; }

        [ForeignKey(nameof(JobId))]
        public virtual Job JobObject { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company CompanyObject { get; set; }
    }
}
