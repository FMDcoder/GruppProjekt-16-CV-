using GruppProjekt_Grupp16_CV.Models;
using System.ComponentModel.DataAnnotations;

namespace GruppProjekt_Grupp16_CV.ModelHelper
{
    public class MessageViewModel
    {
        public List<Message> unreadMessages {  get; set; }
        public List<Message> readMessages { get; set; }
        public List<Message> sentMessages { get; set; }

        public bool[] selectedUnreadMessages { get; set; }
        public bool[] selectedReadMessages { get; set; }
        public bool[] selectedSentMessages { get; set; }

    }
}
