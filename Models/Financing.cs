using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Financing
    {
        [Key]
        public int IdFinancing { get; set; }
        public string? FinancingName { get; set; }

        public virtual ICollection<Operation> Operation { get; set; } = new List<Operation>();
        public virtual ICollection<Polyclinic> Polyclinic { get; set; } = new List<Polyclinic>();
    }
}
