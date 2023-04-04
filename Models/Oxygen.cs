using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Oxygen
    {
        [Key]
        public int OxygenId { get; set; }
        [Display(Name = "Уровень кислорода")]
        public string? Value { get; set; }
        [Display(Name = "Дата")]
        public DateTime? Date { get; set; }

        public string? UserId { get; set; }  // внешний ключ

        public ApplicationUser? User { get; set; }  // свойство навигации
    }
}
