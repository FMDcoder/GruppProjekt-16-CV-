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
		public Repository<MessageBox> messageBox { get; set; }
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
            messageBox = new Repository<MessageBox>(cvContext);
        }

        // Hanterar visning av meddelandet
        public IActionResult MessageOpen([FromRoute] int id)
        {
            return View(messages.GetById(id));
        }
        
        // Hanterar visningen av skicka meddelandet sidan
        public IActionResult SendMessage(SendMessageViewModel sendMessageViewModel)
        {
            return View(
                sendMessageViewModel == null ? new SendMessageViewModel() : sendMessageViewModel
           );
        }

        // Hanterar skickandet av meddalandet via send message sidan
        public IActionResult SendMessageAction(SendMessageViewModel sendMessageViewModel)
        {
			sendMessageViewModel.success = false;
            if (ModelState.IsValid)
            {
                string sentUserId = (
                    from user in users.GetAll()
                    where user.UserName == "Anonym" 
                    select user.Id
                ).First();

                if (User.Identity.IsAuthenticated)
                {
                    sentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    
                }

                List<string> recievedUserIdList = new List<string>();

                string[] userList = sendMessageViewModel.SendTo.Trim().ToUpper().Split(',');
                foreach ((var user, var i) in userList.Select((value, i) => (value, i)))
                {
                    List<string> userFoundId = (
                        from userSearching in users.GetAll()
                        where userSearching.NormalizedUserName == user && !userSearching.Deactivated
                        select userSearching.Id
                    ).ToList();

                    if (userFoundId.Count > 0)
                    {
                        recievedUserIdList.Add(userFoundId[0]);
                    }
                    else
                    {
                        string[] usersTyped = sendMessageViewModel.SendTo.Trim().Split(',');
                        ModelState.AddModelError("", $"Det finns ingen användare som heter {usersTyped[i]}");
                        return View("SendMessage", sendMessageViewModel);
                    }
                }

                Message sendMessage = new Message
                {
                    Title = sendMessageViewModel.Title,
                    Description = sendMessageViewModel.Description,
                };


                messages.Insert(sendMessage);
                messages.Save();

                var messageId = (
                    from message in messages.GetAll()
                    where message.Title == sendMessageViewModel.Title && message.Description == sendMessageViewModel.Description
                    select message
                ).First().Id;

                if (User.Identity.IsAuthenticated)
                {
                    foreach (var recievedUserId in recievedUserIdList)
                    {
                        messageBox.Insert(new MessageBox
                        {
                            SentUserId = sentUserId,
                            RecievedUserId = recievedUserId,
                            MessageId = messageId
                        });
                    }
                }
                else
                {
					foreach (var recievedUserId in recievedUserIdList)
					{
						messageBox.Insert(new MessageBox
						{
							SentUserId = sentUserId,
							RecievedUserId = recievedUserId,
							MessageId = messageId,
							AnonymName = sendMessageViewModel.AnonymName
						});
					}
				}
                    messageBox.Save();
                sendMessageViewModel.success = true;
            }
            return View("SendMessage", sendMessageViewModel);
        }

        // Hanterar visningen av alla olika typer av meddelanden läst, oläst, skickade
        public IActionResult Messages(MessageViewModel messageViewModelRedirected)
        {
            MessageViewModel messageViewModel = new MessageViewModel();

            string userId = (
                from user in users.GetAll()
                where user.UserName == "Anonym"
                select user.Id
            ).First();

            if (User.Identity != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    User user = (
                        from userObject in cvContext.Users
                        where userObject.Id == userId
                        select userObject
                   ).First();

                    List<Message> unreadMessages = (
                        from unreadmessage in user.RecievedMessageBoxes
                        where !(
                            from removedMessage in user.RemovedMessages
                            where removedMessage.UserId == userId
                            select removedMessage.MessageId
                        ).Contains(unreadmessage.MessageId)
                        &&
                        !(
                            from readMessage in user.ReadMessages
                            where readMessage.UserId == userId
                            select readMessage.MessageId
                        ).Contains(unreadmessage.MessageId)
                        && !unreadmessage.SentUserObject.Deactivated
                        select unreadmessage.MessageObject
                     ).ToList();

                    List<Message> readMessages = (
                        from readmessage in user.ReadMessages
                        where !(
                           from removedMessage in user.RemovedMessages
                           where removedMessage.UserId == userId
                           select removedMessage.MessageId
                        ).Contains(readmessage.MessageId) 
                        && !readmessage.MessageObject.MessageBoxes[0].SentUserObject.Deactivated
                        select readmessage.MessageObject
                    ).ToList();

                    List<Message> sentMessages = (
                        from sentMessage in user.SentMessageBoxes
						where !(
						   from removedMessage in user.RemovedMessages
                           where removedMessage.UserId == userId
                           select removedMessage.MessageId
						).Contains(sentMessage.MessageId)
                        && !sentMessage.RecievedUserObject.Deactivated
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
                    List<Message> sentMessages = (
                        from sentMessage in messageBox.GetAll()
                        where sentMessage.SentUserId == userId && !(
                            from removedMessage in removedMessages.GetAll()
                            where removedMessage.UserId == userId
                            select removedMessage.MessageId
                        ).Contains(sentMessage.MessageId)
                        && !sentMessage.RecievedUserObject.Deactivated
                        select sentMessage.MessageObject
                    ).GroupBy(msg => msg.Id).Select(group => group.First()).ToList();

                    messageViewModel.sentMessages = sentMessages;
                    messageViewModel.selectedSentMessages = new bool[sentMessages.Count];
                }
            }
            return View(messageViewModel);
        }

        // Hanterar olästa meddelanden sektion av alla meddelanden sidan
        public IActionResult MessageActionUnread(MessageViewModel messageViewModel, string submitButton)
        {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (submitButton == "Markera som läst")
            {
                foreach ((var item, var i) in messageViewModel.selectedUnreadMessages.Select((value, i) => (value, i)))
                {
                    if (item)
                    {
                        var messageId = messageViewModel.unreadMessages[i].Id;

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

		// Hanterar lästa meddelanden sektion av alla meddelanden sidan
		public IActionResult MessageActionRead(MessageViewModel messageViewModel, string submitButton)
        {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (submitButton == "Markera som oläst")
            {
                foreach ((var item, var i) in messageViewModel.selectedReadMessages.Select((value, i) => (value, i)))
                {
                    if (item)
                    {
                        var messageId = messageViewModel.readMessages[i].Id;

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

		// Hanterar skickade meddelanden sektion av alla meddelanden sidan
		public IActionResult MessageActionSent(MessageViewModel messageViewModel)
        {
			string userId = (
                from user in users.GetAll()
                where user.UserName == "Anonym"
                select user.Id
            ).First();

            if (User.Identity.IsAuthenticated)
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            foreach ((var item, var i) in messageViewModel.selectedSentMessages.Select((value, i) => (value, i)))
            {
                if (item)
                {
                    var messageId = messageViewModel.sentMessages[i].Id;

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
