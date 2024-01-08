using GruppProjekt_Grupp16_CV.ExportModels;
using GruppProjekt_Grupp16_CV.ModelHelper;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Text;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace GruppProjekt_Grupp16_CV.Controllers
{
    public class HomeController : Controller
    {
        private readonly CvContext _cvContext;
        public Repository<Company> companies { get; set; }
        public Repository<Job> jobs { get; set; }
        public Repository<Message> messages { get; set; }
        public Repository<Profession> professions { get; set; } 
        public Repository<Project> projects { get; set; }
        public Repository<MessageBox> messageBox { get; set; }
		public Repository<ReadMessages> readMessages { get; set; }
        public Repository<RemovedMessages> removedMessages { get; set; }
        public Repository<School> schools { get; set; }
        public Repository<Skills> skills { get; set; }
        public Repository<Status> status { get; set; }
        public Repository<User> users { get; set; }
        public Repository<UserEducation> userEducations { get; set; } 
        public Repository<UserExperience> userExperinces { get; set; }
        public Repository<UserProject> userProjects { get; set; }
        public Repository<UserSkills> userSkills { get; set; }
        public Repository<VisitedCV> usersVisit { get; set; }

        public HomeController(CvContext cvContext)
		{
			_cvContext = cvContext;
			companies = new Repository<Company>(cvContext);
			jobs = new Repository<Job>(cvContext);
			messages = new Repository<Message>(cvContext);

			professions = new Repository<Profession>(cvContext);
			projects = new Repository<Project>(cvContext);
			readMessages = new Repository<ReadMessages>(cvContext);

			messageBox = new Repository<MessageBox>(cvContext);

			removedMessages = new Repository<RemovedMessages>(cvContext);
			schools = new Repository<School>(cvContext);
			skills = new Repository<Skills>(cvContext);

			status = new Repository<Status>(cvContext);
			users = new Repository<User>(cvContext);
			userEducations = new Repository<UserEducation>(cvContext);

			userExperinces = new Repository<UserExperience>(cvContext);
			userProjects = new Repository<UserProject>(cvContext);
			userSkills = new Repository<UserSkills>(cvContext);

			usersVisit = new Repository<VisitedCV>(cvContext);
		}

		// Laddar model för framsidan
        public IActionResult Index()
        {
			List<User> usersList = new List<User>();

			if(User.Identity.IsAuthenticated)
			{
				usersList = (
					from user in users.GetAll()
					where user.UserName != "Anonym" && !user.Deactivated
					select user
			   ).ToList();
			}
			else
			{
				usersList = (
					from user in users.GetAll()
					where user.UserName != "Anonym" && !user.Deactivated && user.StatusId == 2
					select user
			   ).ToList();
			}
			
			return View(usersList);
        }

		// Laddar model syn för sökning
        public IActionResult Search()
        {
            return View(new SearchBarValidate());
        }

        public IActionResult Account()
        {
            if(User.Identity != null)
            {
				if (User.Identity.IsAuthenticated)
				{
					return RedirectToAction("Profile", "Account");
				}
			}
            return View();
        }


		// Laddar model syn för CV:et
        public IActionResult CVsite(string id)
        {
			CvDisplayViewModel cvDisplayViewModel = new CvDisplayViewModel();

			User user = (
                from userSearch in users.GetAll()
                where userSearch.Id == (id == null ? cvDisplayViewModel.user.Id : id)
                select userSearch
            ).First();

            cvDisplayViewModel.isOwner = false;


            cvDisplayViewModel.user = user;
			cvDisplayViewModel.SendTo = user.UserName;


			if (User.Identity.IsAuthenticated)
            {
                if (User.FindFirstValue(ClaimTypes.NameIdentifier) != id)
                {
                    List<VisitedCV> visitedCVs = (
                        from userSearch in usersVisit.GetAll()
                        where userSearch.OwnerUserId == User.FindFirstValue(ClaimTypes.NameIdentifier)
							&& userSearch.VisitorUserId == id
                        select userSearch
                    ).ToList();

                    if (visitedCVs.Count == 0)
                    {
                        usersVisit.Insert(new VisitedCV
                        {
                            OwnerUserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
							VisitorUserId = user.Id
                        });
						usersVisit.Save();
                    }
                }
                else
                {
                    cvDisplayViewModel.isOwner = true;
                    cvDisplayViewModel.Visited = (
                        from visitSearch in usersVisit.GetAll()
                        where visitSearch.OwnerUserId == user.Id
						select visitSearch
					).Count();
				}
            }
            return View(cvDisplayViewModel);
        }

		// Hanterar sökning av "liknande folk"
        public IActionResult SimilarPeople(string id)
		{
            User userLogged = (
                from userSearch in users.GetAll()
                where userSearch.Id == id
                select userSearch
            ).First();

			SearchBarValidate searchBarValidate = new SearchBarValidate();

            string search = userLogged.UserName;

			foreach(var skill in userLogged.UserSkills)
			{
				search += " "+skill.SkillsObject.Title;
			}

			searchBarValidate.search = search;

			List<User> usersList = new List<User>();
			if (User.Identity.IsAuthenticated)
			{
				usersList = (
					from user in users.GetAll()
					where user.UserName != "Anonym" && !user.Deactivated
					select user
				).ToList();
			}
			else
			{
				usersList = (
					from user in users.GetAll()
					where user.StatusId == 2 && user.UserName != "Anonym" && !user.Deactivated
					select user
				).ToList();
			}

			usersList.Sort((user0, user1) =>
			{
				int pointsForUser0 = 0;
				int pointsForUser1 = 0;

				List<string> skillsUser0 = (
						from skill in userSkills.GetAll()
						where skill.UserId == user0.Id
						select skill.SkillsObject.Title
					).ToList();

				List<string> skillsUser1 = (
					from skill in userSkills.GetAll()
					where skill.UserId == user1.Id
					select skill.SkillsObject.Title
				).ToList();

				foreach (var strSearch in search.Split(" "))
				{
					foreach (var skill in skillsUser0)
					{
						if (skill.ToUpper().Contains(strSearch.ToUpper()))
						{
							pointsForUser0++;

						}
					}
					if (user0.NormalizedUserName.Contains(strSearch.ToUpper()))
					{
						pointsForUser0 += 5;
					}
				}

				foreach (var strSearch in search.Split(" "))
				{
					foreach (var skill in skillsUser1)
					{
						if (skill.ToUpper().Contains(strSearch.ToUpper()))
						{
							pointsForUser1++;

						}
					}
					if (user1.NormalizedUserName.Contains(strSearch.ToUpper()))
					{
						pointsForUser1 += 5;
					}
				}

				return pointsForUser0 < pointsForUser1 ? 1 : 0;
			});

			return View("Users", usersList);
		}


		// Hanterar skickande av meddelande via CV:et
        [HttpPost]
		public IActionResult SendMessageAction(CvDisplayViewModel sendMessageViewModel, string id)
		{
			sendMessageViewModel.success = false;

			ModelState.Remove("user");
			ModelState.Remove("Visited");
			ModelState.Remove("isOwner");

			if(User.Identity.IsAuthenticated)
			{
				ModelState.Remove("AnonymName");
            }

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
						return View("CVsite", new { id = id});
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

            User client = (
                from userSearch in users.GetAll()
                where userSearch.Id == (id == null ? sendMessageViewModel.user.Id : id)
                select userSearch
            ).First();

            sendMessageViewModel.isOwner = false;


            sendMessageViewModel.user = client;
            sendMessageViewModel.SendTo = client.UserName;


            if (User.Identity.IsAuthenticated)
            {
                if (User.FindFirstValue(ClaimTypes.NameIdentifier) != id)
                {
                    List<VisitedCV> visitedCVs = (
                        from userSearch in usersVisit.GetAll()
                        where userSearch.OwnerUserId == User.FindFirstValue(ClaimTypes.NameIdentifier)
                            && userSearch.VisitorUserId == id
                        select userSearch
                    ).ToList();

                    if (visitedCVs.Count == 0)
                    {
                        usersVisit.Insert(new VisitedCV
                        {
                            OwnerUserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                            VisitorUserId = client.Id
                        });
                        usersVisit.Save();
                    }
                }
                else
                {
                    sendMessageViewModel.isOwner = true;
                    sendMessageViewModel.Visited = (
                        from visitSearch in usersVisit.GetAll()
                        where visitSearch.OwnerUserId == client.Id
                        select visitSearch
                    ).Count();
                }
            }

            return View("CVsite", sendMessageViewModel);
		}

		// Hanter XML fil av CV:et och ner laddning
		public IActionResult downloadCV(string userId)
        {
            User user = (
                from userSearch in users.GetAll()
                where userSearch.Id == userId
				select userSearch
            ).First();

			ExportUser exportUser = new ExportUser();

			exportUser.Name = user.UserName;
			exportUser.Adress = user.Adress;
			exportUser.PhoneNumber = user.PhoneNumber;
			exportUser.Email = user.Email;

			foreach(var education in user.UserEducations)
			{
				exportUser.Educations.Add(new ExportedEducation
				{
					school = education.SchoolObject.Title,
					profession = education.ProfesssionObject.Title,
					time = education.ProfesssionObject.Time+""
				});
			}

			foreach (var experience in user.UserExperinces)
			{
				exportUser.Experience.Add(new ExportedExperience
				{
					company = experience.CompanyObject.Title,
					job = experience.JobObject.Title,
					time = experience.TotalTime + ""
				});
			}


			List<Project> projectsListCreated = (
				from project in projects.GetAll()
				where project.CreatorId == userId
				select project
			).ToList();

			foreach ((var project, var i) in projectsListCreated.Select((item, i) => (item, i)))
			{
				List<string> collab = (
					from userProjects in projectsListCreated[i].UserProject
					select userProjects.UserObject.UserName
				).ToList();

				collab.Add(user.UserName);

				exportUser.CreatedProjects.Add(new ExportedProject
				{
					title = project.Title,
					description	= project.Description,
					lastUpdated = project.LatestUpdate.ToString(),
					collaborators = collab
				});
			}

			List<Project> projectsListCollab = (
				from project in userProjects.GetAll()
				where project.UserId == userId
				select project.ProjectObject
			).ToList();

			foreach ((var project, var i) in projectsListCollab.Select((item, i) => (item, i)))
			{
				List<string> collab = (
					from userProjects in projectsListCreated[i].UserProject
					select userProjects.UserObject.UserName
				).ToList();

				collab.Add(project.CreatorObject.UserName);

				exportUser.CollabratorProjects.Add(new ExportedProject
				{
					title = project.Title,
					description = project.Description,
					lastUpdated = project.LatestUpdate.ToString(),
					collaborators = collab
				});
			}

			foreach (var skill in user.UserSkills)
			{
				exportUser.Skills.Add(new ExportedSkills
				{
					skill = skill.SkillsObject.Title
				});
			}

			foreach (var skill in exportUser.Skills)
			{
				Console.WriteLine(skill.skill);
			}

			var xmlContent = "";
			using(var stringWriter = new StringWriter())
			{
				var writer = new XmlSerializer(typeof(ExportUser));
				writer.Serialize(stringWriter, exportUser);
				xmlContent = stringWriter.ToString();
			}

			var fileName = "CV.xml";
			var contentType = "application/xml";
			var contentDisposition = new System.Net.Mime.ContentDisposition
			{
				FileName = fileName,
				Inline = false
			};
			Response.Headers.Append("Content-Disposition", contentDisposition.ToString());

			return File(Encoding.UTF8.GetBytes(xmlContent), contentType);
		}

		// Hanterar laddningen av project
        public IActionResult Project()
        {
            ProjectViewModel model = new ProjectViewModel();
            model.users = (
                from user in users.GetAll()
                where !user.Deactivated
                select user
            ).ToList();
            model.projects = (
                from project in projects.GetAll()
                where !project.CreatorObject.Deactivated
                select project
            ).ToList();
            return View(model);
        }

		// Hanterar laddningen av synen efter sökningen 
        public IActionResult Users(SearchBarValidate searchBarValidate, string search)
        {
            if (ModelState.IsValid)
            {
                List<User> usersList = new List<User>();
                if (User.Identity.IsAuthenticated)
                {
                    usersList = (
                        from user in users.GetAll()
                        where user.UserName != "Anonym" && !user.Deactivated
                        select user
                    ).ToList();
                }
                else
                {
                    usersList = (
                        from user in users.GetAll()
                        where user.StatusId == 2 && user.UserName != "Anonym" && !user.Deactivated
						select user
                    ).ToList();
                }

                usersList.Sort((user0, user1) =>
                {
                    int pointsForUser0 = 0;
                    int pointsForUser1 = 0;

					List<string> skillsUser0 = (
							from skill in userSkills.GetAll()
							where skill.UserId == user0.Id
							select skill.SkillsObject.Title
						).ToList();

					List<string> skillsUser1 = (
						from skill in userSkills.GetAll()
						where skill.UserId == user1.Id
						select skill.SkillsObject.Title
					).ToList();

                    foreach (var strSearch in search.Split(" "))
                    {
						foreach (var skill in skillsUser0)
						{
                            if(skill.ToUpper().Contains(strSearch.ToUpper())) 
                            {
                                pointsForUser0++;

							}
						}
                        if (user0.NormalizedUserName.Contains(strSearch.ToUpper()))
                        {
                            pointsForUser0 += 5;
                        }
                    }

					foreach (var strSearch in search.Split(" "))
					{
						foreach (var skill in skillsUser1)
						{
							if (skill.ToUpper().Contains(strSearch.ToUpper()))
							{
								pointsForUser1++;

							}
						}
						if (user1.NormalizedUserName.Contains(strSearch.ToUpper()))
						{
							pointsForUser1 += 5;
						}
					}

					return pointsForUser0 < pointsForUser1 ? 1 : 0;
                });

                return View("Users", usersList);
			}
            return View("Search", searchBarValidate);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}