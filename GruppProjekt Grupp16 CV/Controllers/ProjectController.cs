using GruppProjekt_Grupp16_CV.ModelHelper;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace GruppProjekt_Grupp16_CV.Controllers
{
    public class ProjectController : Controller
    {
        public CvContext context;
        public Repository<Project> projects;
        public Repository<User> users;
        public Repository<UserProject> userProjects;

        public ProjectController(CvContext context) {
            this.context = context;

            projects = new Repository<Project>(context);
            users = new Repository<User>(context);
            userProjects = new Repository<UserProject>(context);
        }

        public IActionResult Project(ProjectCreateViewModel projectCreateViewModel)
        {
            projectCreateViewModel = projectCreateViewModel != null ? projectCreateViewModel : new ProjectCreateViewModel();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			ModelState.Remove("userProjects");
			ModelState.Remove("excludedUserProjects");
			ModelState.Remove("hasJoined");

			projectCreateViewModel.userProjects = (
                from project in projects.GetAll()
                where project.CreatorId == userId
                select project
			).ToList();

			projectCreateViewModel.excludedUserProjects = (
				from project in projects.GetAll()
				where project.CreatorId != userId && !project.CreatorObject.Deactivated
				select project
			).ToList();

            projectCreateViewModel.hasJoined 
                    = new bool[projectCreateViewModel.excludedUserProjects.Count];

            foreach((var project, var i) in projectCreateViewModel.excludedUserProjects.Select((item, i) => (item, i)))
            {
                List<UserProject> usersCollab = (
                    from projectCollab in project.UserProject
                    where projectCollab.UserId == userId && !projectCollab.ProjectObject.CreatorObject.Deactivated
                    select projectCollab
                ).ToList();

                if( usersCollab.Any() )
                {
                    projectCreateViewModel.hasJoined[i] = true;
                }
            }


			return View(projectCreateViewModel);
        }

        public IActionResult ProjectEdit([FromRoute] int id)
        {
            AddProjectModelView addProjectModelView = new AddProjectModelView();
            addProjectModelView.currentProject = (
                from project in projects.GetAll()
                where project.Id == id
                select project
            ).First();

            addProjectModelView.validate = new ProjectValidate();
			addProjectModelView.validate.Description = addProjectModelView.currentProject.Description;

            return View(addProjectModelView);
        }

        public IActionResult CreateProject (ProjectCreateViewModel projectCreateViewModel)
        {
			ModelState.Remove("userProjects");
			ModelState.Remove("excludedUserProjects");
			ModelState.Remove("hasJoined");

            if (ModelState.IsValid)
            {
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

				Project newProject = new Project
                {
                    Title = projectCreateViewModel.projectValidate.Title,
                    Description = projectCreateViewModel.projectValidate.Description,
                    LatestUpdate = DateTime.Now,
                    CreatorId = userId
                };

                projects.Insert(newProject);
                projects.Save();
            }
			return RedirectToAction("Project", projectCreateViewModel);
		}

		public IActionResult Edit(AddProjectModelView addProjectModelView, int id)
        {
            ModelState.Remove("currentProject");

			addProjectModelView.currentProject = (
					from project in projects.GetAll()
					where project.Id == id
					select project
				).First();

			if (ModelState.IsValid)
            {
				addProjectModelView.currentProject.Title = addProjectModelView.validate.Title;
                addProjectModelView.currentProject.Description = addProjectModelView.validate.Description;
                addProjectModelView.currentProject.LatestUpdate = DateTime.Now;

                projects.Update(addProjectModelView.currentProject);
                projects.Save();
                return RedirectToAction("Project");

			} 
			return View("ProjectEdit", addProjectModelView);
		}

        public IActionResult CollabProject (int id, string state)
        {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			Project project = (
                from projectState in projects.GetAll()
                where projectState.Id == id
                select projectState
            ).First();

            if(state == "Gå med")
            {
                userProjects.Insert(new UserProject
                {
                    UserId = userId,
                    ProjectId = project.Id,
                });
            }
            else
            {
				userProjects.Delete(
                    (from deleteCollab in userProjects.GetAll()
                    where deleteCollab.UserId == userId && deleteCollab.ProjectId == project.Id
                    select deleteCollab).First()
                );
			}
            userProjects.Save();

            return RedirectToAction("Project");
        }
	}
}
