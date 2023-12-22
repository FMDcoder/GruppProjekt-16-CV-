﻿// <auto-generated />
using System;
using GruppProjekt_Grupp16_CV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GruppProjekt_Grupp16_CV.Migrations
{
    [DbContext(typeof(CvContext))]
    [Migration("20231222213702_Time")]
    partial class Time
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Company");
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

                    b.ToTable("Job");
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

                    b.ToTable("Message");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.MessageBox", b =>
                {
                    b.Property<int>("SentUserId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("RecievedUserId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("MessageId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("SentUserId", "RecievedUserId", "MessageId");

                    b.HasIndex("MessageId");

                    b.ToTable("MessageBox");
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

                    b.ToTable("Profession");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.Project", b =>
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

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.ReadMessages", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("MessageId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "MessageId");

                    b.HasIndex("MessageId");

                    b.ToTable("ReadMessages");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.RemovedMessages", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("MessageId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "MessageId");

                    b.HasIndex("MessageId");

                    b.ToTable("RemovedMessages");
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

                    b.ToTable("School");
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

                    b.ToTable("Skills");
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

                    b.ToTable("Status");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.UserEducation", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
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

                    b.ToTable("UserEducation");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.UserExperince", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
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

                    b.ToTable("UserExperince");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.UserProject", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("UserProject");
                });

            modelBuilder.Entity("GruppProjekt_Grupp16_CV.Models.UserSkills", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("SkillsId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("UserId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("UserSkills");
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
                        .HasForeignKey("MessageId")
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
                    b.Navigation("ReadMessages");

                    b.Navigation("RecievedMessageBoxes");

                    b.Navigation("RemovedMessages");

                    b.Navigation("SentMessageBoxes");

                    b.Navigation("UserEducations");

                    b.Navigation("UserExperinces");

                    b.Navigation("UserProjects");

                    b.Navigation("UserSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
