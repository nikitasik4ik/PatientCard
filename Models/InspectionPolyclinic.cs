using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class InspectionPolyclinic
    {
        [Key]
        public int IdInspectionPoliclinic { get; set; }
        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации
        public int? IdDepartament { get; set; }
        [ForeignKey("IdDepartament")]
        public virtual Departament? Departament { get; set; }
        public int? IdDoctor { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }
        public int? IdService { get; set; }
        [ForeignKey("IdService")]
        public virtual Service? Service { get; set; }
        public string? Complaints { get; set; }
        public string AnamnesisDisease { get; set; } = null!;
        public string? Diagnosis { get; set; }
        public string? Recommendation { get; set; }
        public virtual ICollection<Polyclinic> Polyclinics { get; set; } = new List<Polyclinic>();

    }
}
