using Models;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GruppProjekt_Grupp16_CV.ModelHelper
{
    public class ProjectCreateViewModel
    {
        public ProjectValidate projectValidate {  get; set; } = new ProjectValidate();

		[BindingBehavior(BindingBehavior.Never)]
		public List<Project> userProjects {  get; set; }

		[BindingBehavior(BindingBehavior.Never)]
		public List<Project> excludedUserProjects { get; set; }

		[BindingBehavior(BindingBehavior.Never)]
		public bool[] hasJoined {  get; set; }
    }
}
