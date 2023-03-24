using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class DisabilitySheet
    {
        [Key]
        public int IdDisabilitySheet { get; set; }
        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации
        public int? IdDoctor { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? IdDepartament { get; set; }
        [ForeignKey("IdDepartament")]
        public virtual Departament? Departament { get; set; }
        public int? IdOrganozatiom { get; set; }
        [ForeignKey("IdOrganization")]
        public virtual Organization? Organization { get; set; }
        public DateTime? DateOfSinging { get; set; }
        public string? Reason { get; set; }

    }
}
