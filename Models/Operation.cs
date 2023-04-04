using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PatientCard.Areas.Identity.Data;
using System.ComponentModel;

namespace PatientCard.Models
{
    public class Operation
    {
        [Key]
        public int IdOperation { get; set; }
        [DisplayName("Номер операции")]
        public string? Number { get; set; }

        [DisplayName("Пациент")]
        public string? UserId { get; set; }  // внешний ключ

        [DisplayName("Пациент")]
        public ApplicationUser? User { get; set; }  // свойство навигации

        [DisplayName("Дата операции")]
        public DateTime? DateOperation { get; set; }

        [DisplayName("Название операции")]
        public string? NameOperation { get; set; }

        [DisplayName("Отделение")]
        public int? IdDepartament { get; set; }

        [ForeignKey("IdDepartament")]
        [DisplayName("Отделение")]
        public virtual Departament? Departament { get; set; }

        [DisplayName("Учреждение")]
        public int? IdOrganization { get; set; }

        [ForeignKey("IdOrganization")]
        [DisplayName("Учреждение")]
        public virtual Organization? Organization { get; set; }

        [DisplayName("Диагноз операции")]
        public string? DiagnosisOperation { get; set; }

        [DisplayName("Услуга")]
        public int? IdService { get; set; }

        [ForeignKey("IdService")]
        [DisplayName("Услуга")]
        public virtual Service? Service { get; set; }

        [DisplayName("Продолжительность операции")]
        public TimeSpan? DurationOperation { get; set; }

        [DisplayName("Протокол операции")]
        public string? ProtocolOperation { get; set; }

        [ForeignKey("Financing")]
        [DisplayName("Финансирование")]
        public int? IdFinancing { get; set; }

        [DisplayName("Финансирование")]
        public virtual Financing? Financing { get; set; }

        [DisplayName("Доктор")]
        public int? IdDoctor { get; set; }
        [DisplayName("Доктор")]
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }



    }
}


        //[ForeignKey("IdDepartamnet")]
        //public virtual Departament IdDepartamnetNavigation { get; set; }

        //[ForeignKey("IdDoctorHospital")]
        //public virtual Doctor IdDoctorHospitalNavigation { get; set; }


