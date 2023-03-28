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
    public DbSet<PatientCard.Models.Analyze> Analyze { get; set; } = default!;
    public DbSet<PatientCard.Models.Anthropometry> Anthropometry { get; set; } = default!;
    public DbSet<PatientCard.Models.Departament> Departament { get; set; } = default!;
    public DbSet<PatientCard.Models.DisabilitySheet> DisabilitySheet { get; set; } = default!;
    public DbSet<PatientCard.Models.Doctor> Doctor { get; set; } = default!;
    public DbSet<PatientCard.Models.Financing> Financing { get; set; } = default!;
    public DbSet<PatientCard.Models.Glucose> Glucose { get; set; } = default!;
    public DbSet<PatientCard.Models.MedicalCar> MedicalCar { get; set; } = default!;
    public DbSet<PatientCard.Models.Operation> Operation { get; set; } = default!;
    public DbSet<PatientCard.Models.Organization> Organization { get; set; } = default!;
    public DbSet<PatientCard.Models.Oxygen> Oxygen { get; set; } = default!;
    public DbSet<PatientCard.Models.Polyclinic> Polyclinic { get; set; } = default!;
    public DbSet<PatientCard.Models.Pressure> Pressure { get; set; } = default!;
    public DbSet<PatientCard.Models.Recipe> Recipe { get; set; } = default!;
    public DbSet<PatientCard.Models.Service> Service { get; set; } = default!;
    public DbSet<PatientCard.Models.Stydy> Stydy { get; set; } = default!;
    public DbSet<PatientCard.Models.Temperature> Temperature { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(key => new { key.LoginProvider, key.ProviderKey });
        });
    }

    //base.OnModelCreating(modelBuilder);
    //modelBuilder.Entity<SignatureDoctor>()
    //    .HasIndex(s => s.IdDoctor)
    //    .IsUnique();

    //modelBuilder.Entity<ApplicationUser>()
    //.HasMany<IdentityUserRole<string>>()
    //.WithOne()
    //.HasForeignKey(ur => ur.UserId)
    //.IsRequired();
}
