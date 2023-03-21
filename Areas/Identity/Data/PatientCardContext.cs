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
    public ICollection<Temperature> Temperatures { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //создать свойства
    }
    public DbSet<PatientCard.Models.Temperature> Temperature { get; set; } = default!;
    public DbSet<PatientCard.Models.Anthropometry> Anthropometry { get; set; } = default!;
    public DbSet<PatientCard.Models.Glucose> Glucose { get; set; } = default!;
    public DbSet<PatientCard.Models.Oxygen> Oxygen { get; set; } = default!;
    public DbSet<PatientCard.Models.Pressure> Pressure { get; set; } = default!;
    public DbSet<PatientCard.Models.Doctor> Doctor { get; set; } = default!;
    public DbSet<PatientCard.Models.Analyze> Analyze { get; set; } = default!;
    public DbSet<PatientCard.Models.Departament> Departament { get; set; } = default!;
}
