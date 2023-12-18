﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class MessageBox
    {
        [Key]
        [Column(Order = 0)]
        public int SentUserId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int RecievedUserId { get; set; }

        public virtual ICollection<Message> MessagesList { get; set; } = new List<Message>();

        [ForeignKey(nameof(SentUserId))]
        public virtual User SentUserObject { get; set; } = null!;

        [ForeignKey(nameof(RecievedUserId))]
        public virtual User RecievedUserObject { get; set; } = null!;
    }
}
