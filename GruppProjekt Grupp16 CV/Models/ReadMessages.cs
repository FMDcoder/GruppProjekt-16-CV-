using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class ReadMessages
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }

        [Key, Column(Order = 1)]
        public int MessageId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User UserObject { get; set; }

        [ForeignKey(nameof(MessageId))]
        public virtual Message MessageObject { get; set; }
    }
}
