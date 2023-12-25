using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GruppProjekt_Grupp16_CV.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<User> UserManager { get; set; }
		public SignInManager<User> SignInManager { get; set; }

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			this.UserManager = userManager;
			this.SignInManager = signInManager;
		}

		public IActionResult Register()
		{
			return View();
		}

		public IActionResult LogIn()
		{
			return View();
		}
	}
}
