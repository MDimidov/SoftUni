using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System.Net.Mime;

namespace P01_StudentSystem.Data;

public class StudentSystemContext : DbContext
{
    public StudentSystemContext() 
    {
    }

    public StudentSystemContext(DbContextOptions<StudentSystemContext> options) : base(options) 
    { 
    }


    public DbSet<Student> Students { get; set; } = null!;

    public DbSet<Course> Courses { get; set; } = null!;

    public DbSet<Homework> Homeworks { get; set; } = null!;

    public DbSet<Resource> Resources { get; set; } = null!;

    public DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=MYRO-LAPTOP-HP\\SQLEXPRESS;Database=StudentSystem;Integrated Security=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Fluent API    
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.Property(e => e.StudentId)
            .IsRequired()
            .HasColumnName("StidentId");

            entity.Property(e => e.Name)
            .HasMaxLength(100)
            .IsUnicode(true);

            entity.Property(e => e.PhoneNumber)
            .IsFixedLength(true)
            .IsRequired(false)
            .HasColumnType("CHAR(10)");

            entity.Property(e => e.RegisteredOn)
            .HasColumnName("RegisteredOn")
            .IsRequired();

            entity.Property(e => e.Birthday)
            .IsRequired(false)
            .HasColumnName("Birthday");

            entity.HasMany(e => e.Homeworks)
            .WithOne(h => h.Student)
            .HasForeignKey(h => h.StudentId);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(c => c.CourseId);

            entity.Property(c => c.Name)
            .HasMaxLength(80)
            .IsUnicode (true);

            entity.Property(c => c.Description)
            .IsRequired(false)
            .IsUnicode(true);

            entity.Property(c => c.Price)
            .HasColumnType("DECIMAL(18, 2)");

            entity.HasMany(c => c.Resources)
            .WithOne(r => r.Course)
            .HasForeignKey(r => r.CourseId);

            entity.HasMany(c => c.Homeworks)
            .WithOne(r => r.Course)
            .HasForeignKey(r => r.CourseId);
        });

        modelBuilder.Entity<Resource>(entity => 
        {
            entity.HasKey(r => r.ResourceId);

            entity.Property(r => r.Name)
            .IsUnicode(true)
            .HasMaxLength(50);

            entity.Property(r => r.Url)
            .IsUnicode(false)
            .IsRequired(true);

            entity.HasOne(r => r.Course)
            .WithMany(c => c.Resources)
            .HasForeignKey(r => r.CourseId);
        });

        modelBuilder.Entity<Homework>(entity =>
        {
            entity.HasKey(h => h.HomeworkId);

            entity.HasOne(h => h.Student)
            .WithMany(s => s.Homeworks)
            .HasForeignKey(h => h.StudentId);

            entity.HasOne(h => h.Course)
            .WithMany(c => c.Homeworks)
            .HasForeignKey(h => h.CourseId);
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            //Generate compostie PK
            entity.HasKey(sc => new
            {
                sc.StudentId,
                sc.CourseId
            });

            //Configure FKs
            entity.HasOne(sc => sc.Course)
            .WithMany(c => c.StudentsCourses)
            .HasForeignKey(sc => sc.CourseId);

            entity.HasOne(sc => sc.Student)
            .WithMany(s => s.StudentsCourses)
            .HasForeignKey(sc => sc.StudentId);
        });

        //modelBuilder.Entity<ContentType>(entity =>
        //{
        //    entity.HasNoKey();
        //});
    }
}
