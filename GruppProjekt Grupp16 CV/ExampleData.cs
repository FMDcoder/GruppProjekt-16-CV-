using GruppProjekt_Grupp16_CV.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel;

namespace GruppProjekt_Grupp16_CV
{
    public class DataHandler
    {
        [HttpPost]
        public async static void uploadData(CvContext cvContext)
        {
            String[] Companies = { "Facebook", "Face2Face", "Marabo" };
            for(var i = 0; i < Companies.Length; i++)
            {
                cvContext.Company.Add(new Company
                {
                    Title = Companies[i]
                });
            }
            cvContext.SaveChanges();


            String[] jobs = { "IT", "Städare", "Elektriker", "Försäljare"};
            for (var i = 0; i < jobs.Length; i++)
            {
                cvContext.Job.Add(new Job
                {
                    Title = jobs[i]
                });
            }
            cvContext.SaveChanges();

            String[] ProfessionTitle = { "IT Tekniker", "Logoped", "Ingenjör", "Kok" };
            int[] ProfessionTime = { 5, 7, 4, 3 };
            for(var i = 0; i < ProfessionTitle.Length; i++)
            {
                cvContext.Profession.Add(new Profession
                {
                    Title = ProfessionTitle[i],
                    Time = ProfessionTime[i]
                });
            }
            cvContext.SaveChanges();

            String[] SchoolTitle = { "Lindeskolan", "Örebros Universitet", "Grenadjärskolan"};
            for (var i = 0; i < SchoolTitle.Length; i++)
            {
                cvContext.School.Add(new School
                {
                    Title = SchoolTitle[i],
                });
            }
            cvContext.SaveChanges();

            String[] SkillsTitle = { "Social Kompetens", "Problemlösare", "Datorkunskaper", "Stavnings kunskaper" };
            for (var i = 0; i < SkillsTitle.Length; i++)
            {
                cvContext.Skills.Add(new Skills
                {
                    Title = SkillsTitle[i],
                });
            }
            cvContext.SaveChanges();

            String[] statusTitle = { "Privat", "Offentlig" };
            for (var i = 0; i < statusTitle.Length; i++)
            {
                cvContext.Status.Add(new Status
                {
                    Title = statusTitle[i],
                });
            }
            cvContext.SaveChanges();

            String[] UsersName = { "Jennifer", "Carlos", "Vanessa", "Jacob" };
            String[] UserPhone = { "46472346294", "46622204351", "46263934522", "46322932150"};
            String[] Gmail = { "jen@gmail.com", "car@gmail.com", "van@gmail.com", "jac@gmail.com" };
			String[] Adresses = { "Symfonivägen 5 Örebro", "Symfonivägen 5 Lindesberg", "Symfonivägen 5 Askersund", "Symfonivägen 5 Karlskoga" };
			String[] Profilepic =
            {
                "https://images.pexels.com/photos/415829/pexels-photo-415829.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                "https://hips.hearstapps.com/hmg-prod/images/street-portrait-of-a-young-man-using-mobile-phone-royalty-free-image-1018047498-1564431457.jpg?crop=0.668xw:1.00xh;0.226xw,0&resize=640:*",
                "https://zishidingxin.com/jpg/1592241040775.jpg",
                "https://www.morganstanley.com/content/dam/msdotcom/people/tiles/prateek-dwivedi.jpg"
            };
            String[] Passwords =
            {
                "pasS%123",
                "pasS%word123",
                "pS%w123",
                "pwS%123"
            };

            for (var i = 0; i < Passwords.Length; i++)
            {
                var passwordHasher = new PasswordHasher<IdentityUser>();
                User user = new User
                {
                    UserName = UsersName[i],
                    PhoneNumber = UserPhone[i],
                    Email = Gmail[i],
                    ProfilePicture = Profilepic[i],
                    Adress = Adresses[i],
                    StatusId = 1 // Privat
                };

                user.PasswordHash = passwordHasher.HashPassword(user, Passwords[i]);
                cvContext.User.Add(user);
            }
            cvContext.SaveChanges();

            String[] projectTitles = { "CyberProg", "Hyper AI", "Dali K" };
            String[] projectDescription = {"Hyper säkert system", "Första generalla AI", "AI med känslor"};
            for(var i= 0; i < projectTitles.Length; i++)
            {
                cvContext.Project.Add(new Project
                {
                    Title = projectTitles[i],
                    Description = projectDescription[i],
                    LatestUpdate = new DateTime(),
                    CreatorId = cvContext.User.ToList()[1].Id
                }) ;
            }
            cvContext.SaveChanges();

            String[] messageTitle = { "Hej Världen", "Hej Hej", "Juste Glömde!" };
            String[] messageDesc = { "Detta är ett test meddelande", "Hejdå!", "Jag glömde bort..." };

            for(var i = 0; i < messageTitle.Length;i++) 
            {
                cvContext.Message.Add(new Message
                {
                    Title = messageTitle[i],
                    Description = messageDesc[i]
                });
            }
            cvContext.SaveChanges();

            int[,] msgSent = {{ 1, 3, 2 }, { 3, 4, 1 }, { 1, 2, 3 } };
            for(var i = 0; i < msgSent.GetLength(0); i++)
            {
                cvContext.MessageBox.Add(new MessageBox
                {
                    RecievedUserId = cvContext.User.ToList()[msgSent[i, 0] - 1].Id,
                    SentUserId = cvContext.User.ToList()[msgSent[i, 1] - 1].Id,
                    MessageId = msgSent[i, 2]
                });
            }
            cvContext.SaveChanges();

            int[,] UserEducationValues = { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 2, 2 }, { 4, 3, 3}};
            for (var i = 0; i < UserEducationValues.GetLength(0); i++)
            {
                cvContext.UserEducation.Add(new UserEducation
                {
                    UserId = cvContext.User.ToList()[UserEducationValues[i, 0] - 1].Id,
                    ProfessionId = UserEducationValues[i, 1],
                    SchoolId = UserEducationValues[i, 2]
                });
            }
            cvContext.SaveChanges();

            int[,] UserExperinceValues = { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 2, 2 }, { 4, 3, 3 } };
            for (var i = 0; i < UserExperinceValues.GetLength(0); i++)
            {
                cvContext.UserExperince.Add(new UserExperince
                {
                    UserId = cvContext.User.ToList()[UserExperinceValues[i, 0] - 1].Id,
                    JobId = UserExperinceValues[i, 1],
                    CompanyId = UserExperinceValues[i, 2],
                    TotalTime = new Random().Next(20),
                });
            }
            cvContext.SaveChanges();

            int[,] UserProjectValues = { {1, 1}, { 1, 2}, { 2, 1 }, { 2, 2 }, { 3, 2 }, { 4, 1 }, { 4, 2 }};
            for (var i = 0; i < UserProjectValues.GetLength(0); i++)
            {
                cvContext.UserProject.Add(new UserProject
                {
                    UserId = cvContext.User.ToList()[UserProjectValues[i, 0] - 1].Id,
                    ProjectId = UserProjectValues[i, 1],
                });
            }
            cvContext.SaveChanges();

            int[,] UserSkillsValues = { { 1, 1 }, { 1, 2 }, { 2, 1 }, { 2, 2 }, { 3, 2 }, { 4, 1 }, { 4, 3 } };
            for (var i = 0; i < UserSkillsValues.GetLength(0); i++)
            {
                cvContext.UserSkills.Add(new UserSkills
                {
                    UserId = cvContext.User.ToList()[UserSkillsValues[i, 0] - 1].Id,
                    SkillsId = UserSkillsValues[i, 1],
                });
            }
            cvContext.SaveChanges();
        }
    }
}
