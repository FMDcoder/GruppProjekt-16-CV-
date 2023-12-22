using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),]
        public int Id { get; set; }

        [Required(ErrorMessage = "Varje användare måste ha en namn!")]
        [StringLength(100, ErrorMessage = "Namnet på användaren får inte vara längre än 100 karaktärer!")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Varje användare måste ha ett telefonnummer!")]
        [RegularExpression(@"^\+?[0-9]*$", ErrorMessage = "Telefonnummret får endast vara siffror!")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Varje användare måste ha ett email!")]
        [EmailAddress(ErrorMessage = "Ogiltigt email!")]
        public string Email { get; set; } = null!;

        [RegularExpression(@"^(http(s?)://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?$", ErrorMessage = "Ogiltigt url för profil bild! Endast jpg eller png!")]
        public string? ProfilePicture { get; set; }

        [Required(ErrorMessage = "Varje användare måste ha ett lösenord!")]
        public string Password { get; set; } = null!;

        public int StatusId { get; set; }


        [ForeignKey(nameof(StatusId))]
        public virtual Status statusObject { get; set; } = null!;

        public virtual List<UserExperince> UserExperinces { get; set; } = null!;

        public virtual List<UserEducation> UserEducations { get; set; } = null!;

        public virtual List<UserProject> UserProjects { get; set; } = null!;

        public virtual List<UserSkills> UserSkills { get; set; } = null!;

        public virtual List<RemovedMessages> RemovedMessages { get; set; } = null!;

        public virtual List<MessageBox> RecievedMessageBoxes { get; set; } = null!;
        public virtual List<MessageBox> SentMessageBoxes { get; set; } = null!;

        public virtual List<ReadMessages> ReadMessages { get; set; } = null!;
    }
}
