using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }

        public string? FullNameDoctor { get; set; }

        public string? SignatureDoctor { get; set; }

        //public virtual ICollection<Analyze> Analyzes { get; } = new List<Analyze>();

        //public virtual ICollection<DisabilitySheet> DisabilitySheets { get; } = new List<DisabilitySheet>();

        //public virtual ICollection<InspectionPoliclinic> InspectionPoliclinics { get; } = new List<InspectionPoliclinic>();

        //public virtual ICollection<MedicalCar> MedicalCars { get; } = new List<MedicalCar>();

        //public virtual ICollection<Operation> Operations { get; } = new List<Operation>();

        //public virtual ICollection<Recipe> Recipes { get; } = new List<Recipe>();

        //public virtual ICollection<Study> Studies { get; } = new List<Study>();
    }
}
