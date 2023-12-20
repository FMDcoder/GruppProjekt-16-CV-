using System.ComponentModel.DataAnnotations;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Varje meddelande måste ha en titel!")]
        [StringLength(100, ErrorMessage = "Titeln på meddalandet får inte vara längre än 100 karaktärer!")]
        public string Title { get; set; } = null!;

        [StringLength(1000, ErrorMessage = "Meddelandet får inte ha mer än 1000 karaktärer!")]
        public string? Description { get; set; }

        public virtual List<RemovedMessages> RemovedMessages { get; set; } = null!;

        public virtual List<MessageBox> MessageBoxes { get; set; } = null!;

        public virtual List<ReadMessages> ReadMessages { get; set; } = null!;
    }
}
