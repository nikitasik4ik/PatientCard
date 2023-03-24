using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PatientCard.Areas.Identity.Data;

namespace PatientCard.Models
{
    public class Operation
    {
        [Key]
        public int IdOperation { get; set; }
        public string? UserId { get; set; }  // внешний ключ
        public ApplicationUser? User { get; set; }  // свойство навигации
        public DateTime? DateOperation { get; set; }

        public int? IdDepartament { get; set; }
        [ForeignKey("IdDepartament")]
        public virtual Departament? Departament { get; set; }
        public int? IdOrganization { get; set; }
        [ForeignKey("IdOrganization")]
        public virtual Organization? Organization { get; set; }

        public string? DiagnosisOperation { get; set; }

        public int? IdService { get; set; }
        [ForeignKey("IdService")]
        public virtual Service? Service { get; set; }

        public TimeSpan? DurationOperation { get; set; }

        public string? ProtocolOperation { get; set; }

        public int? IdFinancing { get; set; }
        [ForeignKey("IdFinancing")]
        public virtual Financing? Financing { get; set; }

        public int? IdDoctor { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor? Doctor { get; set; }

        public virtual ICollection<Hospital> Hospital { get; set; } = new List<Hospital>();
    }
}


        //[ForeignKey("IdDepartamnet")]
        //public virtual Departament IdDepartamnetNavigation { get; set; }

        //[ForeignKey("IdDoctorHospital")]
        //public virtual Doctor IdDoctorHospitalNavigation { get; set; }


