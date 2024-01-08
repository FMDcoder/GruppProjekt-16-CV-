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
		public Repository<UserExperience> userExperience { get; set; }
		public Repository<Company> companys { get; set; }
		public Repository<Job> jobs { get; set; }
		public Repository<UserSkills> userSkills { get; set; }
		public Repository<Skills> skills {  get; set; }

		public CvController(CvContext context) {
			userExperience = new Repository<UserExperience>(context);
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
				else if(prevSymbolic)
				{
					result += char.ToUpper(character);
					prevSymbolic = false;
				}
				else 
				{
					result += character;
				}
			}
			return result;
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

			educationExperinceModelView.yourExperience = (
				from experince in userExperience.GetAll()
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
						where professionSearch.Title == profession && professionSearch.Time == time
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

		public IActionResult EducationEdit(EducationValidate changedEducation, string collectiveId)
		{
			changedEducation.id = int.Parse(collectiveId);

			UserEducation education = (
				from userEducationSearch in userEducation.GetAll()
				where userEducationSearch.Id == int.Parse(collectiveId)
				select userEducationSearch
			).First();

			if (ModelState.IsValid)
			{
				EducationValidate educationValidate = new EducationValidate();

				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				string school = formatString(changedEducation.schoolTitle);
				string profession = formatString(changedEducation.professionTitle);
				int time = changedEducation.time;

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
						where professionSearch.Title == profession && professionSearch.Time == time
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
			educationValidateGet.id = int.Parse(collectiveId);

			return View(educationValidateGet);
		}

		public IActionResult ExperienceAdd(ExperienceValidate experienceValidate)
		{
			experienceValidate = experienceValidate != null ? experienceValidate : new ExperienceValidate();
			if (ModelState.IsValid)
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				string company = formatString(experienceValidate.companyTitle);
				string job = formatString(experienceValidate.jobTitle);
				int time = experienceValidate.time;

				var jobId = 0;
				var companyId = 0;

				for (var i = 0; i < 2; i++)
				{
					List<int> companyExists = (
						from companySearch in companys.GetAll()
						where companySearch.Title == company
						select companySearch.Id
					).ToList();

					if (companyExists.Any())
					{
						companyId = companyExists[0];
						break;
					}
					else
					{
						companys.Insert(new Company
						{
							Title = company
						});
						companys.Save();
					}
				}

				for (var i = 0; i < 2; i++)
				{
					List<int> jobExists = (
						from jobSearch in jobs.GetAll()
						where jobSearch.Title == job
						select jobSearch.Id
					).ToList();

					if (jobExists.Any())
					{
						jobId = jobExists[0];
						break;
					}
					else
					{
						jobs.Insert(new Job
						{
							Title = job,
						});
						jobs.Save();
					}
				}

				userExperience.Insert(new UserExperience
				{
					UserId = userId,
					CompanyId = companyId,
					JobId = jobId,
					TotalTime = time
				});
				userExperience.Save();

				return RedirectToAction("EducationExperinceView");
			}
			return View(experienceValidate);
		}

		public IActionResult ExperienceEdit(ExperienceValidate changedExperience, string collectiveId)
		{
			changedExperience.id = int.Parse(collectiveId);

			UserExperience experience = (
				from userExperienceSearch in userExperience.GetAll()
				where userExperienceSearch.Id == int.Parse(collectiveId)
				select userExperienceSearch
			).First();

			if (ModelState.IsValid)
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				string company = formatString(changedExperience.companyTitle);
				string job = formatString(changedExperience.jobTitle);
				int time = changedExperience.time;

				var jobId = 0;
				var companyId = 0;

				for (var i = 0; i < 2; i++)
				{
					List<int> companyExists = (
						from companySearch in companys.GetAll()
						where companySearch.Title == company
						select companySearch.Id
					).ToList();

					if (companyExists.Any())
					{
						companyId = companyExists[0];
						break;
					}
					else
					{
						companys.Insert(new Company
						{
							Title = company
						});
						companys.Save();
					}
				}

				for (var i = 0; i < 2; i++)
				{
					List<int> jobExists = (
						from jobSearch in jobs.GetAll()
						where jobSearch.Title == job
						select jobSearch.Id
					).ToList();

					if (jobExists.Any())
					{
						jobId = jobExists[0];
						break;
					}
					else
					{
						jobs.Insert(new Job
						{
							Title = job,
						});
						jobs.Save();
					}
				}
				userExperience.Delete(experience);
				userExperience.Insert(new UserExperience
				{
					UserId = userId,
					CompanyId = companyId,
					JobId = jobId,
					TotalTime = time
				});
				userExperience.Save();

				return RedirectToAction("EducationExperinceView");
			}

			ExperienceValidate experienceValidateGet = new ExperienceValidate();
			experienceValidateGet.companyTitle = experience.CompanyObject.Title;
			experienceValidateGet.jobTitle = experience.JobObject.Title;
			experienceValidateGet.time = experience.TotalTime;
			experienceValidateGet.id = int.Parse(collectiveId);

			return View(experienceValidateGet);
		}

		public IActionResult SkillsAdd(SkillsValidate skillsValidate)
		{
			skillsValidate = skillsValidate == null ? new SkillsValidate() : skillsValidate;

			if (ModelState.IsValid)
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				string skillsTitle = formatString(skillsValidate.Title);

				var skillsId = 0;

				for (var i = 0; i < 2; i++)
				{
					List<int> skillsExists = (
						from skillsSearch in skills.GetAll()
						where skillsSearch.Title == skillsTitle
						select skillsSearch.Id
					).ToList();

					if (skillsExists.Any())
					{
						skillsId = skillsExists[0];
						break;
					}
					else
					{
						skills.Insert(new Skills
						{
							Title = skillsTitle
						});
						skills.Save();
					}
				}

				userSkills.Insert(new UserSkills
				{
					UserId = userId,
					SkillsId = skillsId
				});
				userSkills.Save();

				return RedirectToAction("EducationExperinceView");
			}
			return View(skillsValidate);
		}

		public IActionResult SkillsEdit(SkillsValidate changedSkills, string collectiveId)
		{
			changedSkills.id = int.Parse(collectiveId);

			UserSkills skillsValidate = (
				from userSkillsSearch in userSkills.GetAll()
				where userSkillsSearch.Id == int.Parse(collectiveId)
				select userSkillsSearch
			).First();

			if (ModelState.IsValid)
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				string skillsTitle = formatString(changedSkills.Title);

				var skillsId = 0;

				for (var i = 0; i < 2; i++)
				{
					List<int> skillsExists = (
						from skillsSearch in skills.GetAll()
						where skillsSearch.Title == skillsTitle
						select skillsSearch.Id
					).ToList();

					if (skillsExists.Any())
					{
						skillsId = skillsExists[0];
						break;
					}
					else
					{
						skills.Insert(new Skills
						{
							Title = skillsTitle
						});
						skills.Save();
					}
				}

				userSkills.Delete(skillsValidate);
				userSkills.Insert(new UserSkills
				{
					UserId = userId,
					SkillsId = skillsId
				});
				userSkills.Save();

				return RedirectToAction("EducationExperinceView");
			}

			SkillsValidate skillsValidateGet = new SkillsValidate();
			skillsValidateGet.Title = skillsValidateGet.Title;
			skillsValidateGet.id = int.Parse(collectiveId);
			return View(skillsValidateGet);
		}
	}
}
