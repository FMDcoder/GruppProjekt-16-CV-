using GruppProjekt_Grupp16_CV.ModelHelper;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Security.Claims;
using System;
using System.IO;

namespace GruppProjekt_Grupp16_CV.Controllers
{
    public class AccountController : Controller
    {
		private UserManager<User> UserManager { get; set; }
		public SignInManager<User> SignInManager { get; set; }

		private readonly CvContext _cvContext;
		public Repository<User> users { get; set; }

        public AccountController(CvContext cvContext, UserManager<User> userManager, SignInManager<User> signInManager)
		{
			this.UserManager = userManager;
			this.SignInManager = signInManager;

			_cvContext = cvContext;
			users = new Repository<User>(_cvContext);
		}

		public async Task<IActionResult> Register(UserRegisterValidate UserRegVal)
		{
			if (ModelState.IsValid && UserRegVal.ProfilePicture != null && UserRegVal.ProfilePicture.Length > 0)
            {
				User client = new User();
				client.UserName = UserRegVal.UserName;
				client.Email = UserRegVal.Email;
				client.EmailConfirmed = true;
				client.StatusId = UserRegVal.Status ? 2 : 1;
				client.PhoneNumber = UserRegVal.PhoneNumber;
				client.ProfilePicture = "";
				client.Adress = UserRegVal.Adress;
				client.Deactivated = false;

                List<User> usedUsername = (
                    from user in users.GetAll()
                    where user.UserName == UserRegVal.UserName
                    select user
                ).ToList();

                if (usedUsername.Count > 0)
                {
                    ModelState.AddModelError("", "Användar namnet används redan!");
                    return View(UserRegVal);
                }

                var res = await UserManager.CreateAsync(client, UserRegVal.Password);
				if(res.Succeeded)
				{
					var imagePath = Path.Combine("wwwroot", "Uploads", $"{client.Id}_profile.jpg");

					using (var stream = new FileStream(imagePath, FileMode.Create))
					{
						await UserRegVal.ProfilePicture.CopyToAsync(stream);
					}

					bool isImage = false;
					string[] allowedContentTypes = { "image/jpeg", "image/png", "image/gif" };
					if(allowedContentTypes.Contains(UserRegVal.ProfilePicture.ContentType))
					{
						client.ProfilePicture = imagePath.Replace("wwwroot", "..");
					} else
					{
						ModelState.AddModelError("", "Filen är inte en png, jpeg eller gif!");
						await UserManager.DeleteAsync(client);
						return View(UserRegVal);
					}
					await UserManager.UpdateAsync(client);

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

		public async Task<IActionResult> LogIn(UserLogInValidate UserLogInVal)
		{

			if(UserLogInVal.UserName == null)
			{
				return View(UserLogInVal);
			}

			if (ModelState.IsValid)
			{
				var client = await UserManager.FindByNameAsync(UserLogInVal.UserName);
				if(client != null)
				{
					if(client.Deactivated)
					{
                        ModelState.AddModelError("", "Kan inte logga in på deaktiverad användare!");
                        return View(UserLogInVal);
                    }

					var signInRes = await SignInManager.PasswordSignInAsync(
						client, UserLogInVal.PasswordHash, UserLogInVal.RememberMe, lockoutOnFailure: false);

					if(signInRes.Succeeded)
					{
						return RedirectToAction("Index", "Home");
					}
					ModelState.AddModelError("", "Lyckades inte logga in!");
				} 
				else
				{
					ModelState.AddModelError("", "Lyckades inte logga in!");
				}
			}
			return View(UserLogInVal);
		}

		public IActionResult Profile()
		{

			ProfileViewModel pvm = new ProfileViewModel();
			pvm.LoggedInUser = (
				from user in users.GetAll()
				where user.Id == User.FindFirstValue(ClaimTypes.NameIdentifier) && !user.Deactivated
				select user
			).First();

			return View(pvm);
		}

		public async Task<IActionResult> LogOut()
        {
			await SignInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

        public async Task<IActionResult> Deactivate()
        {
			User deactivatedUser = (
				from user in users.GetAll()
				where user.Id == User.FindFirstValue(ClaimTypes.NameIdentifier) && !user.Deactivated
				select user
			).First();
			deactivatedUser.Deactivated = true;
			users.Update(deactivatedUser);
			users.Save();

            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> UpdateUser(ProfileViewModel pvm)
		{
			pvm.LoggedInUser = (
				from user in users.GetAll()
				where user.Id == User.FindFirstValue(ClaimTypes.NameIdentifier) && !user.Deactivated
                select user
			).First();

			ModelState.Remove("LoggedInUser");

			if (ModelState.IsValid)
			{
				var client = await UserManager.GetUserAsync(User);
				var token = await UserManager.GeneratePasswordResetTokenAsync(client);
				var result = await UserManager.ResetPasswordAsync(client, token, pvm.Validate.Password);

				if (result.Succeeded)
				{

					var imagePath = Path.Combine("wwwroot", "Uploads", $"{User.FindFirstValue(ClaimTypes.NameIdentifier)}_profile.jpg");

					using (var stream = new FileStream(imagePath, FileMode.Create))
					{
						await pvm.Validate.ProfilePicture.CopyToAsync(stream);
					}

					if (System.IO.File.Exists(client.ProfilePicture))
					{
						System.IO.File.Delete(client.ProfilePicture);
					}

					client.ProfilePicture = imagePath.Replace("wwwroot", "..");

					client.UserName = pvm.Validate.UserName;
					client.Email = pvm.Validate.Email;
					client.EmailConfirmed = true;
					client.StatusId = pvm.Validate.Status ? 2 : 1;
					client.PhoneNumber = pvm.Validate.PhoneNumber;
					client.Adress = pvm.Validate.Adress;

					var res = await UserManager.UpdateAsync(client);

					if (res.Succeeded)
					{
						await SignInManager.RefreshSignInAsync(client);
						return RedirectToAction("Index", "Home");
					}
					else
					{
						foreach (var error in res.Errors)
						{
							ModelState.AddModelError("", error.Description);
						}
					}
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}

			return View("Profile",pvm);
		}
    }
}
