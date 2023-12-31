using Microsoft.AspNetCore.Mvc;
using GruppProjekt_Grupp16_CV.ModelHelper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Models;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GruppProjekt_Grupp16_CV.Controllers
{
    public class MessagesController : Controller
    {
        private readonly CvContext cvContext;

        public MessagesController(CvContext cvContext)
        {
            this.cvContext = cvContext;
        }

        public IActionResult Messages()
        {
            MessageViewModel MVM = new MessageViewModel();

            if (User.Identity != null)
            {
                if(User.Identity.IsAuthenticated) 
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    User user = (
                        from userObject in cvContext.Users
                        where userObject.Id == userId
                        select userObject
                   ).First();

                    List<Message> unreadMessages = (
                        from message in user.RecievedMessageBoxes
                        where !(
                            from removedMessage in user.RemovedMessages
                            select removedMessage.MessageId
                        ).Contains(message.MessageId)
                        &&
                        !(
                            from readMessage in user.ReadMessages
                            select readMessage.MessageId
                        ).Contains(message.MessageId)
                        select message.MessageObject).ToList();

                    List<Message> readMessages = (
                        from message in user.ReadMessages
                        where !(
                           from removedMessage in user.RemovedMessages
                           select removedMessage.MessageId
                        ).Contains(message.MessageId)
                        select message.MessageObject
                    ).ToList();

                    List<Message> sentMessages = (
                        from sentMessage in user.SentMessageBoxes
                        select sentMessage.MessageObject
                    ).ToList();                    

                    MVM.unreadMessages = unreadMessages;
                    MVM.readMessages = readMessages;
                    MVM.sentMessages = sentMessages;
                }
                else
                {

                }
            }

            return View(MVM);
        }
    }
}
