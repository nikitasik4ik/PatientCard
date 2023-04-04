using PatientCard.Areas.Identity.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientCard.Models
{
    public class DisabilitySheet
    {
        [Key]
        public int IdDisabilitySheet { get; set; }

        [DisplayName("Пациент")]
        public string UserId { get; set; }  // внешний ключ

        [Display(Name = "Пациент")]
        public ApplicationUser? User { get; set; }  // свойство навигации

        [DisplayName("Врач")]
        public int? IdDoctor { get; set; }

        [ForeignKey("IdDoctor")]
        [Display(Name = "Врач")]
        public virtual Doctor? Doctor { get; set; }

        [DisplayName("Дата начала")]
        public DateTime FromDate { get; set; }

        [DisplayName("Дата окончания")]
        public DateTime ToDate { get; set; }

        [DisplayName("Отделение")]
        public int? IdDepartament { get; set; }

        [ForeignKey("IdDepartament")]
        [Display(Name = "Отделение")]
        public virtual Departament? Departament { get; set; }

        [DisplayName("Организация")]
        public int? IdOrganization { get; set; }

        [ForeignKey("IdOrganization")]
        [Display(Name = "Организация")]
        public virtual Organization? Organization { get; set; }

        [DisplayName("Дата выдачи")]
        public DateTime DateOfSinging { get; set; }

        [DisplayName("Причина")]
        public string Reason { get; set; }
    }

}
