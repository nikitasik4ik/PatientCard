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
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<PatientCard.Models.Temperature> Temperature { get; set; } = default!;
}
