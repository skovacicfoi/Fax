using Core.Faculties;
using Core.Subjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class FaxDbContext : IdentityDbContext<User>
    {
        public FaxDbContext(DbContextOptions<FaxDbContext> options) : base(options)
        {

        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<PartOfSubject> PartOfSubjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SubjectTimeOfTeaching> SubjectTimeOfTeachings { get; set; }
        public DbSet<StudyProgram> StudyPrograms { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<SubjectStudyProgram> SubjectStudyPrograms { get; set; }
        public DbSet<UserStudyProgram> UserStudyPrograms { get; set; }
        public DbSet<SubjectTemplate> SubjectTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SubjectStudyProgram>()
         .HasKey(bc => new { bc.StudyProgramId, bc.SubjectTemplateId });

            modelBuilder.Entity<SubjectStudyProgram>()
            .HasOne<StudyProgram>(sp => sp.StudyProgram)
            .WithMany(s => s.Subjects)
            .HasForeignKey(sc => sc.StudyProgramId);


            modelBuilder.Entity<SubjectStudyProgram>()
                .HasOne<SubjectTemplate>(sc => sc.SubjectTemplate)
                .WithMany(s => s.StudyPrograms)
                .HasForeignKey(sc => sc.SubjectTemplateId);



            modelBuilder.Entity<UserStudyProgram>()
         .HasKey(bc => new { bc.StudyProgramId, bc.UserId });

            modelBuilder.Entity<UserStudyProgram>()
            .HasOne<StudyProgram>(sp => sp.StudyProgram)
            .WithMany(s => s.Students)
            .HasForeignKey(sc => sc.StudyProgramId);


            modelBuilder.Entity<UserStudyProgram>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.StudyPrograms)
                .HasForeignKey(sc => sc.UserId);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
