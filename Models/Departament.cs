using System;
using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Departament
    {
        [Key]
        public int IdDepartament { get; set; }

        public string? NameDepartament { get; set; }

        public string? OfficeDepartament { get; set; }

        public string? AdressDepartament { get; set; }


        //public virtual ICollection<Analyze> Analyzes { get; set; } = new List<Analyze>();

        //public virtual ICollection<DisabilitySheet> DisabilitySheets { get; set; } = new List<DisabilitySheet>();

        //public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();

        //public virtual ICollection<InspectionHospital> InspectionHospitals { get; set; } = new List<InspectionHospital>();

        //public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();

        //public virtual ICollection<Polyclinic> Polyclinics { get; set; } = new List<Polyclinic>();
        //public virtual ICollection<Reception> Receptions { get; set; } = new List<Reception>();

        //public virtual ICollection<Stydy> Stydies { get; set; } = new List<Stydy>();
    }
}
