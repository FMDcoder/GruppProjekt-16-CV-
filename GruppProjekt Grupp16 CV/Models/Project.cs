using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } 

        [StringLength(1000)]
        public string? Description { get; set; }

        public DateTime LatestUpdate { get; set; }

        public int CreatorId { get; set; }

        public virtual List<UserProject> UserProject { get; set; } = new List<UserProject>();

        [ForeignKey(nameof(CreatorId))]
        public virtual User CreatorObject { get; set; }
    }
}
