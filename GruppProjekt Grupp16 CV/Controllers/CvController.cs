using GruppProjekt_Grupp16_CV.ModelHelper;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Models;
using System.Security.Claims;

namespace GruppProjekt_Grupp16_CV.Controllers
{
	public class CvController : Controller
	{
		public Repository<UserEducation> userEducation { get; set; }
		public Repository<School> schools {  get; set; }
		public Repository<Profession> professions { get; set; }
		public Repository<UserExperince> userExperince { get; set; }
		public Repository<Company> companys { get; set; }
		public Repository<Job> jobs { get; set; }
		public Repository<UserSkills> userSkills { get; set; }
		public Repository<Skills> skills {  get; set; }

		public CvController(CvContext context) {
			userExperince = new Repository<UserExperince>(context);
			userEducation = new Repository<UserEducation>(context);
			userSkills = new Repository<UserSkills>(context);
			schools = new Repository<School>(context);
			professions = new Repository<Profession>(context);
			companys = new Repository<Company>(context);
			jobs = new Repository<Job>(context);
			skills = new Repository<Skills>(context);
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

		public IActionResult EducationAdd(EducationValidate educationValidate)
		{
			educationValidate = educationValidate != null ? educationValidate : new EducationValidate();
			if(ModelState.IsValid)
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				string school = formatString(educationValidate.schoolTitle);
				string profession = formatString(educationValidate.professionTitle);
				int time = educationValidate.time;

				var professionId = 0;
				var schoolId = 0;

				for (var i = 0; i < 2; i++)
				{
					List<int> schoolExists = (
						from schoolSearch in schools.GetAll()
						where schoolSearch.Title == school
						select schoolSearch.Id
					).ToList();

					if (schoolExists.Any())
					{
						schoolId = schoolExists[0];
						break;
					}
					else
					{
						schools.Insert(new School
						{
							Title = school
						});
						schools.Save();
					}
				}

				for (var i = 0; i < 2; i++)
				{
					List<int> professionExists = (
						from professionSearch in professions.GetAll()
						where professionSearch.Title == school && professionSearch.Time == time
						select professionSearch.Id
					).ToList();

					if (professionExists.Any())
					{
						professionId = professionExists[0];
						break;
					}
					else
					{
						professions.Insert(new Profession
						{
							Title = profession,
							Time = time
						});
						professions.Save();
					}
				}

				userEducation.Insert(new UserEducation
				{
					UserId = userId,
					SchoolId = schoolId,
					ProfessionId = professionId
				});
				userEducation.Save();

				return RedirectToAction("EducationExperinceView");
			}
			return View(educationValidate);
		}

		public IActionResult EducationEdit(string collectiveId)
		{
			UserEducation education = (
				from userEducationSearch in userEducation.GetAll()
				where userEducationSearch.Id == int.Parse(collectiveId)
				select userEducationSearch
			).First();

			if (ModelState.IsValid)
			{
				EducationValidate educationValidate = new EducationValidate();

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				string school = formatString(educationValidate.schoolTitle);
				string profession = formatString(educationValidate.professionTitle);
				int time = educationValidate.time;

				var professionId = 0;
				var schoolId = 0;

				for (var i = 0; i < 2; i++)
				{
					List<int> schoolExists = (
						from schoolSearch in schools.GetAll()
						where schoolSearch.Title == school
						select schoolSearch.Id
					).ToList();

					if (schoolExists.Any())
					{
						schoolId = schoolExists[0];
						break;
					}
					else
					{
						schools.Insert(new School
						{
							Title = school
						});
						schools.Save();
					}
				}

				for (var i = 0; i < 2; i++)
				{
					List<int> professionExists = (
						from professionSearch in professions.GetAll()
						where professionSearch.Title == school && professionSearch.Time == time
						select professionSearch.Id
					).ToList();

					if (professionExists.Any())
					{
						professionId = professionExists[0];
						break;
					}
					else
					{
						professions.Insert(new Profession
						{
							Title = profession,
							Time = time
						});
						professions.Save();
					}
				}
				userEducation.Delete(education);
				userEducation.Insert(new UserEducation
				{
					UserId = userId,
					SchoolId = schoolId,
					ProfessionId = professionId
				});
				userEducation.Save();

				return RedirectToAction("EducationExperinceView");
			}

			EducationValidate educationValidateGet = new EducationValidate();
			educationValidateGet.schoolTitle = education.SchoolObject.Title;
			educationValidateGet.professionTitle = education.ProfesssionObject.Title;
			educationValidateGet.time = education.ProfesssionObject.Time;

			return View(educationValidateGet);
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
