using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Financing
    {
        [Key]
        public int FinancingId { get; set; }
        public string FinancingName { get; set; }

        //public virtual ICollection<Operation> Operations { get; set; }
        //public virtual ICollection<Polyclinic> Polyclinics { get; set; }
    }
}
