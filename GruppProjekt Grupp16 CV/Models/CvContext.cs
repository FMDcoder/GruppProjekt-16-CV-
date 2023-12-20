using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class CvContext : DbContext
    {
        public CvContext(DbContextOptions<CvContext> options) : base(options) { }

        public DbSet<Company> Company { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<MessageBox> MessageBox { get; set; }
        public DbSet<Profession> Profession { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ReadMessages> ReadMessages { get; set; }
        public DbSet<RemovedMessages> RemovedMessages { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserEducation> UserEducation { get; set; }
        public DbSet<UserExperince> UserExperince { get; set; }
        public DbSet<UserProject> UserProject { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fixar så att tabeller med fler än en primär nyckel funkar
            modelBuilder.Entity<MessageBox>()
                .HasKey(mb => new { mb.SentUserId, mb.RecievedUserId, mb.MessageId});

            modelBuilder.Entity<MessageBox>()
                .HasOne(mb => mb.SentUserObject)
                .WithMany(t => t.SentMessageBoxes)
                .HasForeignKey(mb => mb.SentUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MessageBox>()
                .HasOne(mb => mb.RecievedUserObject)
                .WithMany(t => t.RecievedMessageBoxes)
                .HasForeignKey(mb => mb.RecievedUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MessageBox>()
                .HasOne(mb => mb.MessageObject)
                .WithMany(t => t.MessageBoxes)
                .HasForeignKey(mb => mb.MessageId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ReadMessages>()
                .HasKey(mb => new { mb.UserId, mb.MessageId});

            modelBuilder.Entity<RemovedMessages>()
                .HasKey(mb => new { mb.UserId, mb.MessageId });

            modelBuilder.Entity<UserEducation>()
                .HasKey(mb => new { mb.UserId, mb.ProfessionId, mb.SchoolId});

            modelBuilder.Entity<UserExperince>()
                .HasKey(mb => new { mb.UserId, mb.JobId, mb.CompanyId});

            modelBuilder.Entity<UserProject>()
                .HasKey(mb => new { mb.UserId, mb.ProjectId});

            modelBuilder.Entity<UserSkills>()
                .HasKey(mb => new { mb.UserId, mb.SkillsId});

            // Fixar så att tabeller funkar med navigerings egenskaper och främmande nycklar
           /* modelBuilder.Entity<MessageBox>()
                .HasOne(s => s.SentUserObject)
                .WithMany(t => t.MessageBoxes)
                .HasForeignKey(s => s.SentUserId);

            modelBuilder.Entity<MessageBox>()
                .HasOne(s => s.RecievedUserObject)
                .WithMany(t => t.MessageBoxes)
                .HasForeignKey(s => s.RecievedUserId);

            modelBuilder.Entity<MessageBox>()
                .HasOne(s => s.MessageObject)
                .WithMany(t => t.MessageBoxes)
                .HasForeignKey(s => s.MessageId);

            modelBuilder.Entity<ReadMessages>()
                .HasOne(s => s.UserObject)
                .WithMany(t => t.ReadMessages)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<ReadMessages>()
                .HasOne(s => s.MessageObject)
                .WithMany(t => t.ReadMessages)
                .HasForeignKey(s => s.MessageId);

            modelBuilder.Entity<RemovedMessages>()
               .HasOne(s => s.UserObject)
               .WithMany(t => t.RemovedMessages)
               .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<RemovedMessages>()
                .HasOne(s => s.MessageObject)
                .WithMany(t => t.RemovedMessages)
                .HasForeignKey(s => s.MessageId);

            modelBuilder.Entity<UserEducation>()
                .HasOne(s => s.UserObject)
                .WithMany(t => t.UserEducations)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<UserEducation>()
                .HasOne(s => s.ProfesssionObject)
                .WithMany(t => t.UserEducations)
                .HasForeignKey(s => s.ProfessionId);

            modelBuilder.Entity<UserEducation>()
                .HasOne(s => s.SchoolObject)
                .WithMany(t => t.UserEducations)
                .HasForeignKey(s => s.SchoolId);

            modelBuilder.Entity<UserExperince>()
                .HasOne(s => s.UserObject)
                .WithMany(t => t.UserExperinces)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<UserExperince>()
                .HasOne(s => s.JobObject)
                .WithMany(t => t.UserExperinces)
                .HasForeignKey(s => s.JobId);

            modelBuilder.Entity<UserExperince>()
                .HasOne(s => s.CompanyObject)
                .WithMany(t => t.UserExperinces)
                .HasForeignKey(s => s.CompanyId);

            modelBuilder.Entity<UserProject>()
                .HasOne(s => s.UserObject)
                .WithMany(t => t.UserProjects)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<UserProject>()
                .HasOne(s => s.ProjectObject)
                .WithMany(t => t.UserProject)
                .HasForeignKey(s => s.ProjectId);

            modelBuilder.Entity<UserSkills>()
               .HasOne(s => s.UserObject)
               .WithMany(t => t.UserSkills)
               .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<UserSkills>()
               .HasOne(s => s.SkillsObject)
               .WithMany(t => t.UserSkills)
               .HasForeignKey(s => s.SkillsId);*/

            base.OnModelCreating(modelBuilder);

            // Exempel Data

        }
    }
}
