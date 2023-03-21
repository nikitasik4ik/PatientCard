using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class InspectionPoliclinic
    {
        [Key]
        public int InspectionPoliclinicId { get; set; }
        public int? DoctorId { get; set; }
        public int? ServiceId { get; set; }
        public string? Complaints { get; set; }
        public string AnamnesisDisease { get; set; } = null!;
        public string? Diagnosis { get; set; }
        public string? Recommendation { get; set; }

        //public virtual Doctor Doctor { get; set; }
        //public virtual Service Service { get; set; }
        //public virtual ICollection<Polyclinic> Polyclinics { get; set; } = new List<Polyclinic>();
    }
}
