using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class Reception
    {
        [Key]
        public int IdReception { get; set; }

        //public string? UserId { get; set; }  // внешний ключ
        //public ApplicationUser? User { get; set; }  // свойство навигации

        public DateTime? Date { get; set; }

        public int? IdDepartament { get; set; }
        [ForeignKey("IdDepartament")]
        public virtual Departament? Departament { get; set; }

        public int? IdDoctor { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }

        public int? IdService { get; set; }
        [ForeignKey("IdService")]
        public virtual Service? Service { get; set; }

        public string? Diagnosis { get; set; }

        public string? Complaints { get; set; }

        public int? IdAnalyze { get; set; }
        [ForeignKey("IdAnalyze")]
        public virtual Analyze? Analyze { get; set; }
        public int? IdStydy { get; set; }
        [ForeignKey("IdStydy")]
        public virtual Stydy? Stydy { get; set; }
        public string? TreatmentPlan { get; set; }

        public string? AnamnesisDisease { get; set; }

        public string? AnamnesisLife { get; set; }

        public virtual ICollection<Hospital> Hospital { get; } = new List<Hospital>();
    }
}




        //public virtual DoctorHospital? DoctorHospital { get; set; }

        //public virtual PersonalData? Person { get; set; }

