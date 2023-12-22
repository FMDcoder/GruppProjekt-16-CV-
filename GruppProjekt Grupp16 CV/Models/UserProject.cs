using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class UserProject
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User UserObject { get; set; } = null!;

        [ForeignKey(nameof(ProjectId))]
        public virtual Project ProjectObject { get; set; } = null!;
    }
}
