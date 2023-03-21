using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Stydy
    {
        [Key]
        public int StydyId { get; set; }

        public int? DepartamentId { get; set; }

        public int? Number { get; set; }

        public int? PersonId { get; set; }

        public DateTime? Date { get; set; }

        public string? Done { get; set; }

        public string? Protocol { get; set; }

        public string? Conclusion { get; set; }

        public int? DoctorId { get; set; }

        //public virtual Departament Departament { get; set; }

        //public virtual Doctor Doctor { get; set; }

        //public virtual PersonalDate Person { get; set; }

        //public virtual ICollection<Polyclinic> Polyclinics { get; set; }

        //public virtual ICollection<Reception> Receptions { get; set; }
    }
}
