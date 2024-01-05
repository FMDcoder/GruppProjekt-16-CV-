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
    public class HomeController : BaseController
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
        public Repository<UserExperince> userExperinces { get; set; }
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

			userExperinces = new Repository<UserExperince>(cvContext);
			userProjects = new Repository<UserProject>(cvContext);
			userSkills = new Repository<UserSkills>(cvContext);

			userVisits = new Repository<VisitedCV>(cvContext);
		}

        public IActionResult Index()
        {
            Console.WriteLine(users.GetAll().Count());
			return View(users.GetAll());
        }

        public IActionResult Privacy()
        {
            return View(users.GetAll());
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
            model.users = users.GetAll().ToList();
            model.projects = projects.GetAll().ToList();
            return View(model);
        }


        public IActionResult Users(string search)
        {
            if(search == null)
            {
                search = string.Empty;
            }

            SearchBarValidate searchBarValidate = new SearchBarValidate{ search = search };
            var results = new List<ValidationResult>();
            var context = new ValidationContext(searchBarValidate);

            if (Validator.TryValidateObject(searchBarValidate, context, results))
            {
                List<User> usersList = new List<User>();
                if (User.Identity.IsAuthenticated)
                {
                    usersList = (
                        from user in users.GetAll()
                        where user.UserName != "Anonym"
                        select user
                    ).ToList();
                }
                else
                {
                    usersList = (
                        from user in users.GetAll()
                        where user.StatusId == 2 && user.UserName != "Anonym"
						select user
                    ).ToList();
                }
                (ViewBag.CommonData as SearchBarValidate).search = search;
                return View(usersList);
			}
            else
            {
                foreach (var error in results)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return RedirectToAction("Index");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
