using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Pressure
    {
        [Key]
        public int PressureId { get; set; }
        [Display(Name = "Давление")]
        public string? Value { get; set; }
        [Display(Name = "Дата")]
        public DateTime? Date { get; set; }

        public string? UserId { get; set; }  // внешний ключ

        public ApplicationUser? User { get; set; }  // свойство навигации
    }
}
