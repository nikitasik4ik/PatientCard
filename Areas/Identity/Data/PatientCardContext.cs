using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PatientCard.Areas.Identity.Data;
using PatientCard.Models;

namespace PatientCard.Data;

public class PatientCardContext : IdentityDbContext<ApplicationUser>
{
    public PatientCardContext(DbContextOptions<PatientCardContext> options)
        : base(options)
    {
    }
    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    //base.OnModelCreating(builder);
    //    //создать свойства

    //}
    public DbSet<PatientCard.Models.Analyze> Analyze { get; set; } = default!;
    public DbSet<PatientCard.Models.Anthropometry> Anthropometry { get; set; } = default!;
    public DbSet<PatientCard.Models.Departament> Departament { get; set; } = default!;
    public DbSet<PatientCard.Models.DisabilitySheet> DisabilitySheet { get; set; } = default!;
    public DbSet<PatientCard.Models.Doctor> Doctor { get; set; } = default!;
    public DbSet<PatientCard.Models.Financing> Financing { get; set; } = default!;
    public DbSet<PatientCard.Models.Glucose> Glucose { get; set; } = default!;
    public DbSet<PatientCard.Models.Hospital> Hospital { get; set; } = default!;
    public DbSet<PatientCard.Models.InspectionHospital> InspectionHospital { get; set; } = default!;
    public DbSet<PatientCard.Models.InspectionPolyclinic> InspectionPoliclinics { get; set; } = default!;
    public DbSet<PatientCard.Models.MedicalCar> MedicalCar { get; set; } = default!;
    public DbSet<PatientCard.Models.Operation> Operation { get; set; } = default!;
    public DbSet<PatientCard.Models.Organization> Organization { get; set; } = default!;
    public DbSet<PatientCard.Models.Oxygen> Oxygen { get; set; } = default!;
    public DbSet<PatientCard.Models.Polyclinic> Polyclinic { get; set; } = default!;
    public DbSet<PatientCard.Models.Pressure> Pressure { get; set; } = default!;
    public DbSet<PatientCard.Models.Reception> Reception { get; set; } = default!;
    public DbSet<PatientCard.Models.Recipe> Recipe { get; set; } = default!;
    public DbSet<PatientCard.Models.Service> Service { get; set; } = default!;
    public DbSet<PatientCard.Models.Stydy> Stydy { get; set; } = default!;
    public DbSet<PatientCard.Models.Temperature> Temperature { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<SignatureDoctor>()
            .HasIndex(s => s.IdDoctor)
            .IsUnique();


        //modelBuilder.Entity<Analyze>()
        //.HasOne(a => a.User)
        //.WithMany()
        //.HasForeignKey(a => a.UserId);

        //modelBuilder.Entity<Doctor>()
        //    .HasMany(d => d.Analyzes)
        //    .WithOne(a => a.Doctor);

        //modelBuilder.Entity<Departament>()
        //    .HasMany(d => d.Analyze)
        //    .WithOne(a => a.Departament);

        //modelBuilder.Entity<Service>()
        //    .HasMany(s => s.Analyzes)
        //    .WithOne(a => a.Service);

        //modelBuilder.Entity<Anthropometry>()
        //    .HasOne(a => a.User)
        //    .WithMany(u => u.Anthropometry)
        //    .HasForeignKey(a => a.UserId);
    }
}
