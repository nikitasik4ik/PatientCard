using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class MedicalCar
    {
        [Key]
        public int IdMedicalCar { get; set; }
        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации
        public DateTime? DateMedicalCar { get; set; }
        public string? PlaceExit { get; set; }
        public string? ReasonExit { get; set; }
        public string? Diagnosis { get; set; }
        public string? ResultExit { get; set; }
        public string? IssueExit { get; set; }
        public int? IdDoctor { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }
        //public virtual PersonalDate IdPersonNavigation { get; set; }
    }
}
