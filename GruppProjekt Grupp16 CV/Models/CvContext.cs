using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<MessageBox>()
                .HasKey(mb => new { mb.SentUserId, mb.RecievedUserId, mb.MessageId});

            modelBuilder.Entity<MessageBox>()
                .HasOne(mb => mb.SentUserObject)
                .WithMany()
                .HasForeignKey(mb => mb.SentUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MessageBox>()
                .HasOne(mb => mb.RecievedUserObject)
                .WithMany()
                .HasForeignKey(mb => mb.RecievedUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MessageBox>()
                .HasOne(mb => mb.MessageObject)
                .WithMany()
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
