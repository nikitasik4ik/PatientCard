using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class Organization
    {
        [Key]
        public int IdOrganization { get; set; }
        public string? Name { get; set; }
        public int? IdDepartament { get; set; }
        public int? IdDoctor { get; set; }
        [ForeignKey("IdDepartament")]
        public virtual Departament? Departament { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }

        public virtual ICollection<Analyze> Analyzes { get; set; } = new List<Analyze>();
        public virtual ICollection<DisabilitySheet> DisabilitySheet { get; set; } = new List<DisabilitySheet>();
        public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();
        public virtual ICollection<Operation> Operation { get; set; } = new List<Operation>();
        public virtual ICollection<Polyclinic> Polyclinic { get; set; } = new List<Polyclinic>();
        public virtual ICollection<Stydy> Stydy { get; set; } = new List<Stydy>(); 
    }
}
