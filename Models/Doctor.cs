using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }

        public string? FullNameDoctor { get; set; }
        [Column("IdSignatureDoctor")]
        public int? IdSignatureDoctor { get; set; }
        [ForeignKey("IdSignatureDoctor")]
        public virtual SignatureDoctor? SignatureDoctor { get; set; }

        public virtual ICollection<Analyze> Analyzes { get; } = new List<Analyze>();

        public virtual ICollection<DisabilitySheet> DisabilitySheet { get; set; } = new List<DisabilitySheet>();

        public virtual ICollection<InspectionPolyclinic> InspectionPolyclinic { get; } = new List<InspectionPolyclinic>();
        public virtual ICollection<InspectionHospital> InspectionHospital { get; } = new List<InspectionHospital>();
        public virtual ICollection<Reception> Reception { get; set; } = new List<Reception>();

        public virtual ICollection<MedicalCar> MedicalCar { get; set; } = new List<MedicalCar>();

        public virtual ICollection<Operation> Operation { get; set; } = new List<Operation>();

        public virtual ICollection<Recipe> Recipe { get; set; } = new List<Recipe>();

        public virtual ICollection<Stydy> Stydy { get; set; } = new List<Stydy>();
    }
}
