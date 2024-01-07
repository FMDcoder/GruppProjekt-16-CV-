using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GruppProjekt_Grupp16_CV
{
    public class DataHandler
    {
        [HttpPost]
        public static void uploadDataAsync(CvContext cvContext, UserManager<User> userManager)
        {
            String[] statusTitle = { "Privat", "Offentlig" };
            for (var i = 0; i < statusTitle.Length; i++)
            {
                cvContext.Status.Add(new Status
                {
                    Title = statusTitle[i],
                });
            }
            cvContext.SaveChanges();

			cvContext.User.Add(new User {
                UserName = "Anonym",
                Email = "Anonym@gmail.com",
                PhoneNumber = "00000000",
                Adress = "Unkown",
                ProfilePicture = "https://media.istockphoto.com/id/1371205496/vector/anonym-encryption-pseudonymisation-icon.jpg?s=612x612&w=0&k=20&c=IuQvr3khiIx6JJY4IngAQzyjXvC-cjyQZhXNEJsPcgU=",
                StatusId = 1
            });

            cvContext.SaveChanges();
        }
    }
}
