using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class Analyze
    {
        [Key]
        public int IdAnalyzes { get; set; }
        public int? IdDepartament { get; set; }
        [ForeignKey("IdDepartament")]
        public virtual Departament? Departament { get; set; }
        public int? IdOrganization { get; set; }
        [ForeignKey("IdOrganization")]
        public Organization? Organization { get; set; }
        public int? IdService { get; set; }
        [ForeignKey("IdService")]
        public virtual Service? Service { get; set; }
        public DateTime? DateAnalyzes { get; set; }
        public int? IdDoctor { get; set; }
        public string? UserId { get; set; }  // внешний ключ
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }
        public ApplicationUser? User { get; set; }  // свойство навигации

        public virtual ICollection<Polyclinic> Polyclinic { get; set; } = new List<Polyclinic>();
        public virtual ICollection<Reception> Receptions { get; set; } = new List<Reception>();
    }
}
