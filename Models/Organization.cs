using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public int? DepartamentId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Departament Departament { get; set; }
        public virtual Doctor Doctor { get; set; }

        //public virtual ICollection<Analyze> Analyzes { get; set; }
        //public virtual ICollection<DisabilitySheet> DisabilitySheets { get; set; }
        //public virtual ICollection<Hospital> Hospitals { get; set; }
        //public virtual ICollection<Operation> Operations { get; set; }
        //public virtual ICollection<Polyclinic> Polyclinics { get; set; }
        //public virtual ICollection<Study> Studies { get; set; }
    }
}
