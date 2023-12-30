using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(maximumLength: 255)]
        public string? ProfilePicture { get; set; }

        [Required]
        [StringLength(maximumLength: 255)]
        public string? Adress;

        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public virtual Status statusObject { get; set; }

        public virtual List<UserExperince> UserExperinces { get; set; } = new List<UserExperince>();

        public virtual List<UserEducation> UserEducations { get; set; } = new List<UserEducation>();

        public virtual List<UserProject> UserProjects { get; set; } = new List<UserProject>();

        public virtual List<Project> CreatedUserProjects { get; set; } = new List<Project>();

        public virtual List<UserSkills> UserSkills { get; set; } = new List<UserSkills>();

        public virtual List<RemovedMessages> RemovedMessages { get; set; } = new List<RemovedMessages>();

        public virtual List<MessageBox> RecievedMessageBoxes { get; set; } = new List<MessageBox>();
        public virtual List<MessageBox> SentMessageBoxes { get; set; } = new List<MessageBox>();

        public virtual List<ReadMessages> ReadMessages { get; set; } = new List<ReadMessages>();

        public virtual List<VisitedCV> VisitedCV { get; set; } = new List<VisitedCV>();
        public virtual List<VisitedCV> VisitorsCV { get; set; } = new List<VisitedCV>();
	}
}
