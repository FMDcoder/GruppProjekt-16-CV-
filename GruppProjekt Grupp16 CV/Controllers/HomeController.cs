using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
        public Repository<UserExperince> userExperinces { get; set; }
        public Repository<UserProject> userProjects { get; set; }
        public Repository<UserSkills> userSkills { get; set; }

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
		}

		public IActionResult Index()
        {
			return View(users.GetAll());
        }

        public IActionResult Privacy()
        {
            return View(users.GetAll());
        }

        public IActionResult Account()
        {
            return View();
        }

		public IActionResult LogIn()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		public IActionResult Profile()
		{
			return View();
		}


		public IActionResult CVsite()
        {
            return View();
        }
        public IActionResult Messages()
        {
            return View();

        }

        public IActionResult Project()
        {
            return View();

        }

        public IActionResult Users()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
