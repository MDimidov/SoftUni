using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Common;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
            
        }

        public HospitalContext(DbContextOptions options) 
            : base(options)
        {

        }

        public DbSet<Diagnose> Diagnose { get; set; } = null!;

        public DbSet<Doctor> Doctor { get; set; } = null!;

        public DbSet<Medicament> Medicament { get; set; } = null!;

        public DbSet<Patient> Patients { get; set; } = null!;

        public DbSet<PatientMedicament> Prescriptions { get; set; } = null!;    

        public DbSet<Visitation> Visitations { get; set; } = null!;


        //To Configure Connection to DB
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        //Fluent API Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(p => p.Email)
                .IsUnicode(false);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new
                {
                    pm.PatientId,
                    pm.MedicamentId
                });
            });

        }
    }
}