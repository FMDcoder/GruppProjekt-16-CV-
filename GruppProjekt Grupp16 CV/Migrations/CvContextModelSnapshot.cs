﻿// <auto-generated />
using System;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GruppProjekt_Grupp16_CV.Migrations
{
    [DbContext(typeof(CvContext))]
    partial class CvContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Job", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Message", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.MessageBox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<string>("RecievedUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SentUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("RecievedUserId");

                    b.HasIndex("SentUserId");

                    b.ToTable("MessageBox", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Profession", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("LatestUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.ReadMessages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("ReadMessages", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.RemovedMessages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("UserId");

                    b.ToTable("RemovedMessages", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("School", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Skills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Skills", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("StatusId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.UserEducation", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<int>("ProfessionId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("SchoolId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("UserId", "ProfessionId", "SchoolId");

                    b.HasIndex("ProfessionId");

                    b.HasIndex("SchoolId");

                    b.ToTable("UserEducation", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.UserExperince", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<int>("JobId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("TotalTime")
                        .HasColumnType("int");

                    b.HasKey("UserId", "JobId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("JobId");

                    b.ToTable("UserExperince", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.UserProject", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("UserProject", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.UserSkills", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.Property<int>("SkillsId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("UserSkills", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.VisitedCV", b =>
                {
                    b.Property<string>("OwnerUserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<string>("VisitorUserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(0);

                    b.HasKey("OwnerUserId", "VisitorUserId");

                    b.HasIndex("VisitorUserId");

                    b.ToTable("UserVisits", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.MessageBox", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.Message", "MessageObject")
                        .WithMany("MessageBoxes")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", "RecievedUserObject")
                        .WithMany("RecievedMessageBoxes")
                        .HasForeignKey("RecievedUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", "SentUserObject")
                        .WithMany("SentMessageBoxes")
                        .HasForeignKey("SentUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MessageObject");

                    b.Navigation("RecievedUserObject");

                    b.Navigation("SentUserObject");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Project", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", "CreatorObject")
                        .WithMany("CreatedUserProjects")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatorObject");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.ReadMessages", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.Message", "MessageObject")
                        .WithMany("ReadMessages")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", "UserObject")
                        .WithMany("ReadMessages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MessageObject");

                    b.Navigation("UserObject");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.RemovedMessages", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.Message", "MessageObject")
                        .WithMany("RemovedMessages")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", "UserObject")
                        .WithMany("RemovedMessages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MessageObject");

                    b.Navigation("UserObject");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.User", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.Status", "statusObject")
                        .WithMany("UserStatus")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("statusObject");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.UserEducation", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.Profession", "ProfesssionObject")
                        .WithMany("UserEducations")
                        .HasForeignKey("ProfessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppProjekt_Grupp16_CV.Models.School", "SchoolObject")
                        .WithMany("UserEducations")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", "UserObject")
                        .WithMany("UserEducations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfesssionObject");

                    b.Navigation("SchoolObject");

                    b.Navigation("UserObject");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.UserExperince", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.Company", "CompanyObject")
                        .WithMany("UserExperinces")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppProjekt_Grupp16_CV.Models.Job", "JobObject")
                        .WithMany("UserExperinces")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", "UserObject")
                        .WithMany("UserExperinces")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyObject");

                    b.Navigation("JobObject");

                    b.Navigation("UserObject");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.UserProject", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.Project", "ProjectObject")
                        .WithMany("UserProject")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", "UserObject")
                        .WithMany("UserProjects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectObject");

                    b.Navigation("UserObject");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.UserSkills", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.Skills", "SkillsObject")
                        .WithMany("UserSkills")
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", "UserObject")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SkillsObject");

                    b.Navigation("UserObject");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.VisitedCV", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", "OwnerUserObject")
                        .WithMany("VisitorsCV")
                        .HasForeignKey("OwnerUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", "VisitorUserObject")
                        .WithMany("VisitedCV")
                        .HasForeignKey("VisitorUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("OwnerUserObject");

                    b.Navigation("VisitorUserObject");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GruppProjekt_Grupp16_CV.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Company", b =>
                {
                    b.Navigation("UserExperinces");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Job", b =>
                {
                    b.Navigation("UserExperinces");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Message", b =>
                {
                    b.Navigation("MessageBoxes");

                    b.Navigation("ReadMessages");

                    b.Navigation("RemovedMessages");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Profession", b =>
                {
                    b.Navigation("UserEducations");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Project", b =>
                {
                    b.Navigation("UserProject");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.School", b =>
                {
                    b.Navigation("UserEducations");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Skills", b =>
                {
                    b.Navigation("UserSkills");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Status", b =>
                {
                    b.Navigation("UserStatus");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.User", b =>
                {
                    b.Navigation("CreatedUserProjects");

                    b.Navigation("ReadMessages");

                    b.Navigation("RecievedMessageBoxes");

                    b.Navigation("RemovedMessages");

                    b.Navigation("SentMessageBoxes");

                    b.Navigation("UserEducations");

                    b.Navigation("UserExperinces");

                    b.Navigation("UserProjects");

                    b.Navigation("UserSkills");

                    b.Navigation("VisitedCV");

                    b.Navigation("VisitorsCV");
                });
#pragma warning restore 612, 618
        }
    }
}
