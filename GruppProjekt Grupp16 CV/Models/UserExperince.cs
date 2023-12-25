using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class UserExperince
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }

        [Key, Column(Order = 1)]
        public int JobId { get; set; }

        [Key, Column(Order = 2)]
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
