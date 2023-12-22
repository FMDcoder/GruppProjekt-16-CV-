using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Varje meddelande måste ha en titel!")]
        [StringLength(100, ErrorMessage = "Titeln på meddalandet får inte vara längre än 100 karaktärer!")]
        public string Title { get; set; } 

        [StringLength(1000, ErrorMessage = "Meddelandet får inte ha mer än 1000 karaktärer!")]
        public string? Description { get; set; }

        public virtual List<RemovedMessages> RemovedMessages { get; set; } = new List<RemovedMessages>();

        public virtual List<MessageBox> MessageBoxes { get; set; } = new List<MessageBox>();

        public virtual List<ReadMessages> ReadMessages { get; set; } = new List<ReadMessages>();
    } 
}
