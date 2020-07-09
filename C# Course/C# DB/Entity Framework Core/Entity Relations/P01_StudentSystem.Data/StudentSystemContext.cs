using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext: DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity.Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

                entity.Property(s => s.PhoneNumber)
                .HasColumnType("CHAR(10)")
                .HasMaxLength(10)
                .IsUnicode(false);

                entity.Property(s => s.RegisteredOn)
                .IsRequired();
                

                //entity.HasMany(s => s.CourseEnrollments)
                //.WithOne(sc => sc.Student)
                //.HasForeignKey(sc => sc.StudentId);

                //entity.HasMany(s => s.HomeworkSubmissions)
                //.WithOne(h => h.Student)
                //.HasForeignKey(s => s.HomeworkId);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);

                entity.Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

                entity.Property(c => c.Description)
                .HasColumnType("NVARCHAR(MAX)");

                entity.Property(c => c.StartDate)
                .IsRequired();

                entity.Property(c => c.StartDate)
                .IsRequired();

                entity.Property(c => c.Price)
                .IsRequired();

            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);

                entity.Property(r => r.Name)
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(r => r.Url)
                .IsRequired(true);

                entity.Property(r => r.ResourceType)
                .IsRequired();

                entity.HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(x => x.CourseId)
                .IsRequired();
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(h => h.HomeworkId);

                entity.Property(h => h.Content)
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired(true);
                
                entity.Property(h => h.ContentType)
                .IsRequired();

                entity.Property(h => h.SubmissionTime)
                .IsRequired();

                entity.Property(h => h.StudentId)
                .IsRequired();

                entity.Property(h => h.CourseId)
                .IsRequired();

                entity.HasOne(h => h.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(h => h.StudentId);

                entity.HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity.Property(sc => sc.CourseId).IsRequired();

                entity.Property(sc => sc.CourseId).IsRequired();

                entity.HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId);

                entity.HasOne(sc => sc.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}
