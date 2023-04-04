using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class MedicalCar
    {
        [Key]
        public int IdMedicalCar { get; set; }
        [Display(Name = "Пациент")]
        public string? UserId { get; set; }  // внешний ключ

        [Display(Name = "Пациент")]
        public ApplicationUser? User { get; set; }  // свойство навигации

        [Display(Name = "Дата выезда")]
        public DateTime? DateMedicalCar { get; set; }

        [Display(Name = "Место выезда")]
        public string? PlaceExit { get; set; }

        [Display(Name = "Причина выезда")]
        public string? ReasonExit { get; set; }

        [Display(Name = "Диагноз")]
        public string? Diagnosis { get; set; }

        [Display(Name = "Результат выезда")]
        public string? ResultExit { get; set; }

        [Display(Name = "Документация")]
        public string? IssueExit { get; set; }

        [Display(Name = "Доктор")]
        public int? IdDoctor { get; set; }

        [ForeignKey("IdDoctor")]
        [Display(Name = "Доктор")]
        public virtual Doctor? Doctor { get; set; }
    }
}
