using GruppProjekt_Grupp16_CV.ModelHelper;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GruppProjekt_Grupp16_CV.Controllers
{
    public class CreateController : Controller
    {
        public CvContext context;
        public Repository<Project> projects;
        public Repository<User> users;
        public Repository<UserProject> userProjects;

        public CreateController(CvContext context) {
            this.context = context;

            projects = new Repository<Project>(context);
            users = new Repository<User>(context);
            userProjects = new Repository<UserProject>(context);
        }

        public IActionResult Education()
        {
            return View();
        }

        public IActionResult Project()
        {
            ProjectCreateViewModel projectCreateViewModel = new ProjectCreateViewModel();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			projectCreateViewModel.userProjects = (
                from project in userProjects.GetAll()
                where project.ProjectObject.CreatorId == userId
                select project.ProjectObject
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

            return View(addProjectModelView);
        }

        public IActionResult Edit(AddProjectModelView addProjectModelView)
        {


			return RedirectToAction("Project");
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
