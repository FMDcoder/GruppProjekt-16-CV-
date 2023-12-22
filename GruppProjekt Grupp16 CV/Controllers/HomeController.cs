using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GruppProjekt_Grupp16_CV.Controllers
{
    public class HomeController : Controller
    {
        private readonly CvContext _cvContext;
        public List<Company> companies { get; set; } = new List<Company>();
        public List<Job> jobs { get; set; } = new List<Job>();
        public List<Message> messages { get; set; } = new List<Message>();
        public List<Profession> professions { get; set; } = new List<Profession>();
        public List<Project> projects { get; set; } = new List<Project>();
        public List<ReadMessages> readMessages { get; set; } = new List<ReadMessages>();
        public List<RemovedMessages> removedMessages { get; set; } = new List<RemovedMessages>();
        public List<School> schools { get; set; } = new List<School>();
        public List<Skills> skills { get; set; } = new List<Skills>();
        public List<Status> status { get; set; } = new List<Status>();
        public List<User> users { get; set; } = new List<User>();
        public List<UserEducation> userEducations { get; set; } = new List<UserEducation>();
        public List<UserExperince> userExperinces { get; set; } = new List<UserExperince>();
        public List<UserProject> userProjects { get; set; } = new List<UserProject>();
        public List<UserSkills> userSkills { get; set; } = new List<UserSkills>();

        public HomeController(CvContext cvContext)
        {
            _cvContext = cvContext;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Code executed when the button is clicked
            Console.WriteLine("Clicked!");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Account()
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
