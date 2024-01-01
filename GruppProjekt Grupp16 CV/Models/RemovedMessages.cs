using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class RemovedMessages
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		public string? UserId { get; set; }
        public int MessageId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User UserObject { get; set; }

        [ForeignKey(nameof(MessageId))]
        public virtual Message MessageObject { get; set; }
    }
}
