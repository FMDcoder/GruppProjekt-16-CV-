using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GruppProjekt_Grupp16_CV.ModelHelper
{
	public class ProfileViewModel
    {
		[BindingBehavior(BindingBehavior.Never)]
		public virtual User LoggedInUser { get; set; }

		public virtual UserRegisterValidate Validate { get; set; }
	}
}
