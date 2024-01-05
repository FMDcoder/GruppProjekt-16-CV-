using Models;
using GruppProjekt_Grupp16_CV.Models;

namespace GruppProjekt_Grupp16_CV.ModelHelper
{
    public class ProjectCreateViewModel
    {
        public ProjectValidate projectValidate {  get; set; } = new ProjectValidate();
        public List<Project> userProjects {  get; set; }
        public List<Project> excludedUserProjects { get; set; }

        public bool[] hasJoined {  get; set; }
    }
}
