using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

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

		public async Task<IActionResult> Register(UserRegisterValidate UserRegVal)
		{
            if(ModelState.IsValid)
            {
				User client = new User();
				client.UserName = UserRegVal.UserName;
				client.Email = UserRegVal.Email;
				client.EmailConfirmed = true;
				client.StatusId = UserRegVal.Status ? 2 : 1;
				client.ProfilePicture = UserRegVal.ProfilePicture;
				client.PhoneNumber = UserRegVal.PhoneNumber;
				var res = await UserManager.CreateAsync(client, UserRegVal.Password);
				if(res.Succeeded)
				{
					await SignInManager.SignInAsync(client, isPersistent: true);
					return RedirectToAction("Index", "Home");
				}

				foreach(var error in res.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
            }
            return View(UserRegVal);
		}

		public IActionResult LogIn()
		{
			return View();
		}
	}
}
