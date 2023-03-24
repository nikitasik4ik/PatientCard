using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class Stydy
    {
        [Key]
        public int IdStydy { get; set; }

        public int? IdDepartament { get; set; }
        [ForeignKey("IdDepartament")]
        public virtual Departament? Departament { get; set; }
        public int? IdOrganization { get; set; }
        [ForeignKey("IdOrganization")]
        public virtual Organization? Organization { get; set; }
        public int? Number { get; set; }

        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации

        public DateTime? Date { get; set; }

        public string? Done { get; set; }

        public string? Protocol { get; set; }

        public string? Conclusion { get; set; }

        public int? IdDoctor { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }

        public virtual ICollection<Polyclinic> Polyclinics { get; set; } = new List<Polyclinic>();
        public virtual ICollection<Reception> Reception { get; set; } = new List<Reception>();
    }
}



