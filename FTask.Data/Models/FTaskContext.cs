using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FTask.Data.Models
{
    public partial class FTaskContext : DbContext
    {
        public FTaskContext()
        {
        }

        public FTaskContext(DbContextOptions<FTaskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<PlanSemester> PlanSemesters { get; set; }
        public virtual DbSet<PlanSubject> PlanSubjects { get; set; }
        public virtual DbSet<PlanTopic> PlanTopics { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectGroup> SubjectGroups { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskCategory> TaskCategories { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.Id).HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PlanSemester>(entity =>
            {
                entity.ToTable("PlanSemester");

                entity.HasIndex(e => e.SemesterId, "IX_PlanSemester_SemesterID");

                entity.HasIndex(e => e.StudentId, "IX_PlanSemester_StudentCode");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SemesterId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.PlanSemesters)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanSemester_Semester");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.PlanSemesters)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanSemester_Student");
            });

            modelBuilder.Entity<PlanSubject>(entity =>
            {
                entity.ToTable("PlanSubject");

                entity.HasIndex(e => e.PlanSemesterId, "IX_PlanSubject_PlanSemesterID");

                entity.HasIndex(e => e.SubjectId, "IX_PlanSubject_SubjectID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.PlanSemester)
                    .WithMany(p => p.PlanSubjects)
                    .HasForeignKey(d => d.PlanSemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanSubject_PlanSemester");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.PlanSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanSubject_Subject");
            });

            modelBuilder.Entity<PlanTopic>(entity =>
            {
                entity.ToTable("PlanTopic");

                entity.HasIndex(e => e.TopicId, "IX_PlanTopic_TopicID");

                entity.HasOne(d => d.PlanSubject)
                    .WithMany(p => p.PlanTopics)
                    .HasForeignKey(d => d.PlanSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanTopic_PlanSubject1");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.PlanTopics)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanTopic_Topic");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.Id).HasMaxLength(10);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MajorId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Major");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.HasIndex(e => e.SubjectGroupId, "IX_Subject_SubjectGroupID");

                entity.Property(e => e.Id).HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Source).HasMaxLength(50);

                entity.HasOne(d => d.SubjectGroup)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.SubjectGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_SubjectGroup");
            });

            modelBuilder.Entity<SubjectGroup>(entity =>
            {
                entity.ToTable("SubjectGroup");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.HasIndex(e => e.PlanTopicId, "IX_Task_PlanTopicID");

                entity.HasIndex(e => e.TaskCategoryId, "IX_Task_TaskCategoryID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.PlanTopic)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.PlanTopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_PlanTopic");

                entity.HasOne(d => d.TaskCategory)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_TaskCategory");
            });

            modelBuilder.Entity<TaskCategory>(entity =>
            {
                entity.ToTable("TaskCategory");

                entity.Property(e => e.TaskType)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.HasIndex(e => e.SubjectId, "IX_Topic_SubjectID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Topic_Subject");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
