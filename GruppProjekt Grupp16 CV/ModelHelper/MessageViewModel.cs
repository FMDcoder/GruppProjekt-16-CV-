using GruppProjekt_Grupp16_CV.Models;

namespace GruppProjekt_Grupp16_CV.ModelHelper
{
    public class MessageViewModel
    {
        public virtual List<Message> unreadMessages {  get; set; }
        public virtual List<Message> readMessages { get; set; }
        public virtual List<Message> sentMessages { get; set; }

        public virtual bool[] selectedUnreadMessages { get; set; }
        public virtual bool[] selectedReadMessages { get; set; }
        public virtual bool[] selectedSentMessages { get; set; }

    }
}
