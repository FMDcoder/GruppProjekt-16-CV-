using Microsoft.AspNetCore.Mvc;
using GruppProjekt_Grupp16_CV.ModelHelper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Models;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GruppProjekt_Grupp16_CV.Controllers
{
    public class MessagesController : Controller
    {
        private readonly CvContext cvContext;

        public Repository<Message> messages { get; set; }
        public Repository<ReadMessages> readMessages { get; set; }
        public Repository<RemovedMessages> removedMessages { get; set; }
        public Repository<User> users { get; set; }

        public MessagesController(CvContext cvContext)
        {
            this.cvContext = cvContext;

            messages = new Repository<Message>(cvContext);
            readMessages = new Repository<ReadMessages>(cvContext);
            removedMessages = new Repository<RemovedMessages>(cvContext);
            users = new Repository<User>(cvContext);
        }

        public IActionResult MessageOpen([FromRoute] int id)
        {
            return View(messages.GetById(id));
        }
        
        public IActionResult SendMessage()
        {
            return View(new SendMessageViewModel());
        }

        public IActionResult SendMessageAction()
        {
            return RedirectToAction("SendMessage");
        }

        public IActionResult Messages()
        {
            MessageViewModel messageViewModel = new MessageViewModel();

            if (User.Identity != null)
            {
                if (User.Identity.IsAuthenticated)
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

                    messageViewModel.unreadMessages = unreadMessages;
                    messageViewModel.readMessages = readMessages;
                    messageViewModel.sentMessages = sentMessages;

                    messageViewModel.selectedUnreadMessages = new bool[unreadMessages.Count];
                    messageViewModel.selectedReadMessages = new bool[readMessages.Count];
                    messageViewModel.selectedSentMessages = new bool[sentMessages.Count];
                }
                else
                {

                }
            }

            return View(messageViewModel);
        }

        public IActionResult MessageActionUnread(MessageViewModel messageViewModel, string submitButton)
        {
            if (submitButton == "Markera som läst")
            {
                foreach ((var item, var i) in messageViewModel.selectedUnreadMessages.Select((value, i) => (value, i)))
                {
                    if (item)
                    {
                        var messageId = messageViewModel.unreadMessages[i].Id;
                        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                        readMessages.Insert(new ReadMessages
                        {
                            MessageId = messageId,
                            UserId = userId
                        });
                    }
                }
                readMessages.Save();
            }
            else
            {
                foreach ((var item, var i) in messageViewModel.selectedUnreadMessages.Select((value, i) => (value, i)))
                {
                    if (item)
                    {
                        var messageId = messageViewModel.unreadMessages[i].Id;
                        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                        removedMessages.Insert(new RemovedMessages
                        {
                            MessageId = messageId,
                            UserId = userId
                        });
                    }
                }
                removedMessages.Save();
            }
            return RedirectToAction("Messages");
        }

        public IActionResult MessageActionRead(MessageViewModel messageViewModel, string submitButton)
        {
            if (submitButton == "Markera som oläst")
            {
                foreach ((var item, var i) in messageViewModel.selectedReadMessages.Select((value, i) => (value, i)))
                {
                    if (item)
                    {
                        var messageId = messageViewModel.readMessages[i].Id;
                        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                        readMessages.Delete(
                            (
                                from unreadMessage in readMessages.GetAll()
                                where unreadMessage.MessageId == messageId && unreadMessage.UserId == userId
                                select unreadMessage
                            ).First()
                        );
                    }
                }
                readMessages.Save();
            }
            else
            {
                foreach ((var item, var i) in messageViewModel.selectedReadMessages.Select((value, i) => (value, i)))
                {
                    if (item)
                    {
                        var messageId = messageViewModel.readMessages[i].Id;
                        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                        removedMessages.Insert(new RemovedMessages
                        {
                            MessageId = messageId,
                            UserId = userId
                        });
                    }
                }
                removedMessages.Save();
            }
            return RedirectToAction("Messages");
        }

        public IActionResult MessageActionSent(MessageViewModel messageViewModel)
        {
            foreach ((var item, var i) in messageViewModel.selectedSentMessages.Select((value, i) => (value, i)))
            {
                if (item)
                {
                    var messageId = messageViewModel.sentMessages[i].Id;
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    removedMessages.Insert(new RemovedMessages
                    {
                        MessageId = messageId,
                        UserId = userId
                    });
                }
            }
            removedMessages.Save();
            return RedirectToAction("Messages");
        }
    }
}
