using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class MessageBox
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		public string? SentUserId { get; set; }
        public string RecievedUserId { get; set; }
        public string? AnonymName { get; set; } = "";
        public int MessageId { get; set; }

        [ForeignKey(nameof(SentUserId))]
        public virtual User SentUserObject { get; set; }

        [ForeignKey(nameof(RecievedUserId))]
        public virtual User RecievedUserObject { get; set; }

        [ForeignKey(nameof(MessageId))]
        public virtual Message MessageObject { get; set; }
    }
}
