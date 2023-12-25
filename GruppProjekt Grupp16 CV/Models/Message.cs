using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } 

        [StringLength(1000)]
        public string? Description { get; set; }

        public virtual List<RemovedMessages> RemovedMessages { get; set; } = new List<RemovedMessages>();

        public virtual List<MessageBox> MessageBoxes { get; set; } = new List<MessageBox>();

        public virtual List<ReadMessages> ReadMessages { get; set; } = new List<ReadMessages>();
    } 
}
