using Microsoft.VisualBasic;
using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class Polyclinic
    {
        [Key]
        public int IdPolyclinic { get; set; }

        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации

        public DateTime? Date { get; set; }

        public int? IdDepartament { get; set; }
        [ForeignKey("IdDepartament")]
        public virtual Departament? Departament { get; set; }
        public int? IdOrganization { get; set; }
        [ForeignKey("IdOrganization")]
        public virtual Organization? Organization { get; set; }

        public string? Complaints { get; set; }

        public string? Reason { get; set; }
        public int? IdFinancing { get; set; }
        [ForeignKey("IdFinancing")]
        public virtual Financing? Financing { get; set; }

        public string? Conditions { get; set; }
        public string AnamnesisDisease { get; set; } = null!;
        public string? Diagnosis { get; set; }
        public string? Recommendation { get; set; }
        public int? IdDoctor { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }
    }

}
        //public virtual Financing Financing { get; set; }
        //public virtual Analyze Analyze { get; set; }
        //public virtual PersonalDate Person { get; set; }
