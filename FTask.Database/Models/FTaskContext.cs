using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FTask.Database.Models
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
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.MajorId).HasMaxLength(20);

                entity.Property(e => e.MajorName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PlanSemester>(entity =>
            {
                entity.ToTable("PlanSemester");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.PlanSemesterName).HasMaxLength(50);

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
                    .HasConstraintName("FK__PlanSemes__Semes__37A5467C");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.PlanSemesters)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanSemes__Stude__38996AB5");
            });

            modelBuilder.Entity<PlanSubject>(entity =>
            {
                entity.ToTable("PlanSubject");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.PlanSemester)
                    .WithMany(p => p.PlanSubjects)
                    .HasForeignKey(d => d.PlanSemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanSubje__PlanS__398D8EEE");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.PlanSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanSubje__Subje__3A81B327");
            });

            modelBuilder.Entity<PlanTopic>(entity =>
            {
                entity.ToTable("PlanTopic");

                entity.HasOne(d => d.PlanSubject)
                    .WithMany(p => p.PlanTopics)
                    .HasForeignKey(d => d.PlanSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanTopic__PlanS__3B75D760");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.PlanTopics)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanTopic_Topic");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.SemesterId).HasMaxLength(10);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.SemesterName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasMaxLength(20);

                entity.Property(e => e.MajorId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StudentEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Student__MajorId__3D5E1FD2");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectId).HasMaxLength(10);

                entity.Property(e => e.Source).HasMaxLength(50);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.SubjectGroup)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.SubjectGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subject__Subject__3E52440B");
            });

            modelBuilder.Entity<SubjectGroup>(entity =>
            {
                entity.ToTable("SubjectGroup");

                entity.Property(e => e.SubjectGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.TaskDescription)
                    .IsRequired()
                    .HasMaxLength(200);

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
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TopicDescription).HasMaxLength(200);

                entity.Property(e => e.TopicName)
                    .IsRequired()
                    .HasMaxLength(150);

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
