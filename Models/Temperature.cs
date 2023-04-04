using PatientCard.Areas.Identity.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace PatientCard.Models
{
    public class Temperature
    {
        [Key]
        public int TemperatureId { get; set; }
        [Display(Name = "Температура")]
        [Range(33.0, 42.0, ErrorMessage = "Значение температуры должно быть в диапазоне от 33 до 42")]
        [RegularExpression(@"^\d{2}\.\d$", ErrorMessage = "Значение температуры должно быть в формате ##.#")]
        public string? Value { get; set; }
        [Display(Name = "Дата")]
        public DateTime? Date { get; set; }
        [Display(Name = "Пациент")]
        public string? UserId { get; set; }  // внешний ключ
        [Display(Name = "Пациент")]
        public ApplicationUser? User { get; set; }  // свойство навигации
    }
}
