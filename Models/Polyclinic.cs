using Microsoft.VisualBasic;
using PatientCard.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class Polyclinic
    {
        [Key]
        public int IdPolyclinic { get; set; }
        [Display(Name = "Пациент")]
        public string? UserId { get; set; }  // внешний ключ
        [Display(Name = "Пациент")]
        public ApplicationUser? User { get; set; }  // свойство навигации
        [Display(Name = "Дата")]
        public DateTime? Date { get; set; }
        [Display(Name = "Отделение")]
        public int? IdDepartament { get; set; }
        [ForeignKey("IdDepartament")]
        [Display(Name = "Отделение")]
        public virtual Departament? Departament { get; set; }
        [Display(Name = "Учреждение")]
        public int? IdOrganization { get; set; }
        [ForeignKey("IdOrganization")]
        [Display(Name = "Учреждение")]
        public virtual Organization? Organization { get; set; }
        [Display(Name = "Жалобы")]
        public string? Complaints { get; set; }
        [Display(Name = "Причина")]
        public string? Reason { get; set; }
        [Display(Name = "Финансирование")]
        public int? IdFinancing { get; set; }
        [ForeignKey("IdFinancing")]
        [Display(Name = "Финансирование")]
        public virtual Financing? Financing { get; set; }
        [Display(Name = "Состояние")]
        public string? Conditions { get; set; }
        [Display(Name = "Анамнез заболевания")]
        public string AnamnesisDisease { get; set; } = null!;
        [Display(Name = "Диагноз")]
        public string? Diagnosis { get; set; }
        [Display(Name = "Рекоммендации")]
        public string? Recommendation { get; set; }
        [Display(Name = "Доктор")]
        public int? IdDoctor { get; set; }
        [Display(Name = "Доктор")]
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }
    }

}
        //public virtual Financing Financing { get; set; }
        //public virtual Analyze Analyze { get; set; }
        //public virtual PersonalDate Person { get; set; }
