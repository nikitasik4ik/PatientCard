using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class Analyze
    {
        [Key]
        public int IdAnalyzes { get; set; }
        [Display(Name = "Организация")]
        public int? IdDepartament { get; set; }
        [ForeignKey("IdDepartament")]
        [Display(Name = "Организация")]
        public virtual Departament? Departament { get; set; }
        [Display(Name = "Отделение")]
        public int? IdOrganization { get; set; }
        [ForeignKey("IdOrganization")]
        [Display(Name = "Отделение")]
        public Organization? Organization { get; set; }
        [Display(Name = "Услуга")]
        public int? IdService { get; set; }
        [ForeignKey("IdService")]
        [Display(Name = "Услуга")]
        public virtual Service? Service { get; set; }
        [Display(Name = "Дата")]
        public DateTime? DateAnalyzes { get; set; }
        [Display(Name = "Доктор")]
        public int? IdDoctor { get; set; }
        [Display(Name = "Пациент")]
        public string? UserId { get; set; }  // внешний ключ
        [ForeignKey("IdDoctor")]
        [Display(Name = "Доктор")]
        public virtual Doctor? Doctor { get; set; }
        [Display(Name = "Пациент")]
        public ApplicationUser? User { get; set; }  // свойство навигации
        
    }
}
