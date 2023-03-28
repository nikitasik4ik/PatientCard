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

        public virtual ICollection<Analyze> Analyze { get; set; } = new List<Analyze>();
        public virtual ICollection<DisabilitySheet> DisabilitySheet { get; set; } = new List<DisabilitySheet>();
        public virtual ICollection<Polyclinic> Polyclinic { get; set; } = new List<Polyclinic>();
        public virtual ICollection<Stydy> Stydy { get; set; } = new List<Stydy>();
        public virtual ICollection<Operation> Operation { get; set; } = new List<Operation>();

    }
}