using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Reception
    {
        [Key]
        public int ReceptionId { get; set; }

        public int? PersonId { get; set; }

        public DateTime? Date { get; set; }

        public int? DepartmentId { get; set; }

        public int? DoctorHospitalId { get; set; }

        public int? ServiceId { get; set; }

        public string? Diagnosis { get; set; }

        public string? Complaints { get; set; }

        public int? AnalyzeId { get; set; }

        public int? StudyId { get; set; }

        public string? TreatmentPlan { get; set; }

        public string? AnamnesisDisease { get; set; }

        public string? AnamnesisLife { get; set; }

        //public virtual ICollection<Hospital> Hospitals { get; } = new List<Hospital>();

        //public virtual Analyze? Analyze { get; set; }

        //public virtual Department? Department { get; set; }

        //public virtual DoctorHospital? DoctorHospital { get; set; }

        //public virtual PersonalData? Person { get; set; }

        //public virtual Service? Service { get; set; }

        //public virtual Study? Study { get; set; }
    }
}
