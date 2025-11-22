using Microsoft.EntityFrameworkCore;
using TestTask_Domain.Entites;
using TestTask_Domain.ValueObject;

namespace TestTask_Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Disease> Diseases => Set<Disease>();
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
            .Property(p => p.Name)
            .HasConversion(
                v => v.Value,
                v => FullName.Create(v))
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();
        
        modelBuilder.Entity<Doctor>()
            .Property(d => d.Name)
            .HasConversion(
                v => v.Value,
                v => FullName.Create(v))
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();
        
        modelBuilder.Entity<Patient>()
            .HasOne<Doctor>()
            .WithMany()
            .HasForeignKey(p => p.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Patient>()
            .HasMany<Disease>()
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "PatientDiseases",
                r => r.HasOne<Disease>().WithMany().HasForeignKey("DiseaseId"),
                r => r.HasOne<Patient>().WithMany().HasForeignKey("PatientId"),
                r =>
                {
                    r.HasKey("PatientId", "DiseaseId");
                    r.ToTable("PatientDisease");
                });
    }
}