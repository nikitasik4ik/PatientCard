using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Glucose
    {
        [Key]
        public int GlucoseId { get; set; }
        [Display(Name = "Уровень глюкозы")]
        public string? Value { get; set; }
        [Display(Name = "Дата")]
        public DateTime? Date { get; set; }

        public string? UserId { get; set; }  // внешний ключ

        public ApplicationUser? User { get; set; }  // свойство навигации
    }
}
