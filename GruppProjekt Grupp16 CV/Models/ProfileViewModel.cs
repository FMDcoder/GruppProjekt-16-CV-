using Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GruppProjekt_Grupp16_CV.Models
{
	public class ProfileViewModel
	{
		public User LoggedInUser { get; set; }

		public UserRegisterValidate Validate { get; set; }
	}
}
