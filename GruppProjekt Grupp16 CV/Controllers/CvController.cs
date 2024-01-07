using GruppProjekt_Grupp16_CV.ModelHelper;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GruppProjekt_Grupp16_CV.Controllers
{
	public class CvController : Controller
	{
		public Repository<UserEducation> userEducation { get; set; }
		public Repository<UserExperince> userExperince { get; set; }
		public Repository<UserSkills> userSkills { get; set; }

		public CvController(CvContext context) {
			userExperince = new Repository<UserExperince>(context);
			userEducation = new Repository<UserEducation>(context);
			userSkills = new Repository<UserSkills>(context);
		}

		private string formatString(string str)
		{
			string result = "";
			char[] spaceOutString = str.ToLower().ToCharArray();

			bool prevSymbolic = true;
			foreach (char character in spaceOutString)
			{
				if(char.IsSymbol(character) || char.IsDigit(character) || char.IsWhiteSpace(character))
				{
					result += character;
					prevSymbolic = true;
				}
				if(prevSymbolic)
				{
					result += char.ToUpper(character);
					prevSymbolic = false;
				}
			}
			return str;
		}

		public IActionResult EducationExperinceView()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			EducationExperinceModelView educationExperinceModelView = new EducationExperinceModelView();

			educationExperinceModelView.yourEducation = (
				from education in userEducation.GetAll()
				where education.UserId == userId
				select education
			).ToList();

			educationExperinceModelView.yourExperince = (
				from experince in userExperince.GetAll()
				where experince.UserId == userId
				select experince
			).ToList();

			educationExperinceModelView.yourSkills = (
				from skills in userSkills.GetAll()
				where skills.UserId == userId
				select skills
			).ToList();

			return View(educationExperinceModelView);
		}

		public IActionResult EducationAdd()
		{
			return View();
		}

		public IActionResult EducationEdit()
		{
			return View();
		}

		public IActionResult ExperinceAdd()
		{
			return View();
		}

		public IActionResult ExperinceEdit()
		{
			return View();
		}

		public IActionResult SkillsAdd()
		{
			return View();
		}

		public IActionResult SkillsEdit()
		{
			return View();
		}
	}
}
