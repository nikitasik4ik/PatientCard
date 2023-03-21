using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Anthropometry
    {
        [Key]
        public int AnthropometryId { get; set; }
        public string? Value { get; set; }
        public DateTime? Date { get; set; }

        public string? UserId { get; set; }  // внешний ключ

        public ApplicationUser? User { get; set; }  // свойство навигации
    }
}
