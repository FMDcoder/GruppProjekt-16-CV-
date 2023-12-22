using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;

namespace GruppProjekt_Grupp16_CV.Models
{
    public class CvContext : DbContext
    {
        public CvContext(DbContextOptions<CvContext> options) : base(options) { 
            
        }

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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies(); // Install the Microsoft.EntityFrameworkCore.Proxies NuGet package
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fixar så att tabeller med fler än en primär nyckel funkar
            modelBuilder.Entity<MessageBox>()
                .HasKey(mb => new { mb.SentUserId, mb.RecievedUserId, mb.MessageId});

            /*modelBuilder.Entity<MessageBox>()
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
                .OnDelete(DeleteBehavior.NoAction);*/

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
                .HasKey(mb => new { mb.UserId, mb.SkillsId });

            modelBuilder.Entity <MessageBox>()
                .HasOne(mb => mb.RecievedUserObject)
                .WithMany(t => t.RecievedMessageBoxes)
                .HasForeignKey(mb => mb.RecievedUserId)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MessageBox>()
                .HasOne(mb => mb.SentUserObject)
                .WithMany(t => t.SentMessageBoxes)
                .HasForeignKey(mb => mb.SentUserId)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MessageBox>()
                .HasOne(mb => mb.MessageObject)
                .WithMany(t => t.MessageBoxes)
                .HasForeignKey(mb => mb.MessageId)
                .IsRequired().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ReadMessages>()
                .HasOne(mb => mb.UserObject)
                .WithMany(t => t.ReadMessages)
                .HasForeignKey(mb => mb.UserId).IsRequired();

            modelBuilder.Entity<ReadMessages>()
                .HasOne(mb => mb.MessageObject)
                .WithMany(t => t.ReadMessages)
                .HasForeignKey(mb => mb.MessageId).IsRequired();

            modelBuilder.Entity<RemovedMessages>()
                .HasOne(mb => mb.UserObject)
                .WithMany(t => t.RemovedMessages)
                .HasForeignKey(mb => mb.UserId).IsRequired();

            modelBuilder.Entity<RemovedMessages>()
                .HasOne(mb => mb.MessageObject)
                .WithMany(t => t.RemovedMessages)
                .HasForeignKey(mb => mb.MessageId).IsRequired();

            modelBuilder.Entity<UserEducation>()
                .HasOne(mb => mb.UserObject)
                .WithMany(t => t.UserEducations)
                .HasForeignKey(mb => mb.UserId).IsRequired();

            modelBuilder.Entity<UserEducation>()
                .HasOne(mb => mb.ProfesssionObject)
                .WithMany(t => t.UserEducations)
                .HasForeignKey(mb => mb.ProfessionId).IsRequired();

            modelBuilder.Entity<UserEducation>()
                .HasOne(mb => mb.SchoolObject)
                .WithMany(t => t.UserEducations)
                .HasForeignKey(mb => mb.SchoolId).IsRequired();

            modelBuilder.Entity<UserExperince>()
                .HasOne(mb => mb.UserObject)
                .WithMany(t => t.UserExperinces)
                .HasForeignKey(mb => mb.UserId).IsRequired();

            modelBuilder.Entity<UserExperince>()
                .HasOne(mb => mb.JobObject)
                .WithMany(t => t.UserExperinces)
                .HasForeignKey(mb => mb.JobId).IsRequired();

            modelBuilder.Entity<UserExperince>()
                .HasOne(mb => mb.CompanyObject)
                .WithMany(t => t.UserExperinces)
                .HasForeignKey(mb => mb.CompanyId).IsRequired();

            modelBuilder.Entity<UserProject>()
                .HasOne(mb => mb.UserObject)
                .WithMany(t => t.UserProjects)
                .HasForeignKey(mb => mb.UserId).IsRequired();

            modelBuilder.Entity<UserProject>()
                .HasOne(mb => mb.ProjectObject)
                .WithMany(t => t.UserProject)
                .HasForeignKey(mb => mb.ProjectId).IsRequired();

            modelBuilder.Entity<UserSkills>()
                .HasOne(mb => mb.UserObject)
                .WithMany(t => t.UserSkills)
                .HasForeignKey(mb => mb.UserId).IsRequired();

            modelBuilder.Entity<UserSkills>()
                .HasOne(mb => mb.SkillsObject)
                .WithMany(t => t.UserSkills)
                .HasForeignKey(mb => mb.SkillsId).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
