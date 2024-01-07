using GruppProjekt_Grupp16_CV.ModelHelper;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Claims;
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
		public Repository<VisitedCV> userVisits { get; set; }

		public HomeController(CvContext cvContext)
		{
			_cvContext = cvContext;
			companies = new Repository<Company>(cvContext);
			jobs = new Repository<Job>(cvContext);
			messages = new Repository<Message>(cvContext);

			professions = new Repository<Profession>(cvContext);
			projects = new Repository<Project>(cvContext);
			readMessages = new Repository<ReadMessages>(cvContext);

			removedMessages = new Repository<RemovedMessages>(cvContext);
			schools = new Repository<School>(cvContext);
			skills = new Repository<Skills>(cvContext);

			status = new Repository<Status>(cvContext);
			users = new Repository<User>(cvContext);
			userEducations = new Repository<UserEducation>(cvContext);

			userExperinces = new Repository<UserExperience>(cvContext);
			userProjects = new Repository<UserProject>(cvContext);
			userSkills = new Repository<UserSkills>(cvContext);

			userVisits = new Repository<VisitedCV>(cvContext);
		}

        public IActionResult Index()
        {
            List<User> usersList = (
                from user in users.GetAll()
                where user.UserName != "Anonym"
                select user
           ).ToList();
            
			return View(usersList);
        }

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

		public IActionResult CVsite()
        {
            return View();
        }

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
